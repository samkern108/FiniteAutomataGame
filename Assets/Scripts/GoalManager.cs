using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GoalManager : MonoBehaviour {

	private static List<Goal> goals;
	public static Goal currentGoal;
	private static int goalIterator = -1;

	public void NextGoal()
	{
		goalIterator++;
		if (goalIterator >= goals.Count) {
			UIManager.instance.UpdateGoalText("Good job!  You finished the game!");
			return;
		}
		currentGoal = goals [goalIterator];
		UIManager.instance.UpdateGoalText(currentGoal.goalText);
	}

	public void TestMachine()
	{
		UIManager.instance.UpdateStatusText ("");

		if (State.startState == null) {
			UIManager.instance.UpdateStatusText ("Build a machine before testing!");
			return;
		}

		foreach (TestCase c in currentGoal.testCases) {
			State currentState = State.startState;

			foreach(TransitionArrow.TransitionColor color in c.colorList)
			{
				foreach(TransitionArrow st in currentState.myTransitionsFrom)
				{
					if(st.myTransitionColor == color)
					{
						currentState = st.end;
					}
				}
			}

			if (currentState.myType == State.type.reject && !c.pass) {
				Debug.Log ("Failed successfully:  " + c.stringFormat);
			} 
			else if(currentState.myType == State.type.accept && c.pass) {
				Debug.Log ("Passed successfully:  "  + c.stringFormat);
			}
			else {
				Debug.Log ("Failed or passed incorrectly:  "  + c.stringFormat);
				UIManager.instance.UpdateStatusText("Failed test case:  " + c.stringFormat);
				return;
			}
		}

		UIManager.instance.UpdateStatusText ("Passed all test cases!");
		NextGoal ();
	}

	void Start () {
		goals = new List<Goal> ();

		List<TestCase> testCases; 
		testCases = new List<TestCase> () {
			new TestCase("bybyybby", true),
			new TestCase("yy", true),
			new TestCase("bbbbby", true),
			new TestCase("bbbbbbb", false),
			new TestCase("yyyyy", true),
			new TestCase("y", true),
			new TestCase("ybbbbbb", true),
			new TestCase("", false)
		};

		goals.Add (new Goal("At least one yellow.", testCases));

		testCases = new List<TestCase> () {
			new TestCase("bybbbb", true),
			new TestCase("bbbbbbb", true),
			new TestCase("yyyyyyyy", false),
			new TestCase("ybbbbb", true),
			new TestCase("ybbbbby", false),
			new TestCase("", false)
		};

		goals.Add (new Goal("Ends with a blue", testCases));

		testCases = new List<TestCase> () {
			new TestCase("bybybybyb", true),
			new TestCase("bbbbb", false),
			new TestCase("yyyyy", true),
			new TestCase("ybbbb", true),
			new TestCase("", true)
		};

		goals.Add (new Goal("An even number of blue. (Zero is even)", testCases));

		testCases = new List<TestCase> () {
			new TestCase("byb", true),
			new TestCase("bbb", true),
			new TestCase("yyyy", false),
			new TestCase("ybbbyybbyby", false),
			new TestCase("", true)
		};

		goals.Add (new Goal("Does not have more than three yellow", testCases));

		testCases = new List<TestCase> () {
			new TestCase("bybyy", true),
			new TestCase("bbbybyyb", false),
			new TestCase("yyyy", true),
			new TestCase("ybbbyybbyby", false),
			new TestCase("", false),
			new TestCase("y", false)
		};

		goals.Add (new Goal("Ends with two yellow", testCases));

		NextGoal ();
	}
}

public class Goal
{
	public string goalText;
	public List<TestCase> testCases;
	
	public Goal(string text, List<TestCase> cases)
	{
		goalText = text;
		testCases = cases;
	}
}

public class TestCase
{
	public List<TransitionArrow.TransitionColor> colorList  = new List<TransitionArrow.TransitionColor>();
	public bool pass;
	public string stringFormat;
	public TestCase(string testCase, bool p)
	{
		stringFormat = testCase;

		foreach(char c in testCase.ToCharArray())
		{
			if(c == 'y') {
				colorList.Add (TransitionArrow.TransitionColor.yellow);
			}
			else if(c == 'b') {
				colorList.Add (TransitionArrow.TransitionColor.blue);
			}
			else {
				Debug.LogError("HEY you have an invalid character in your testcase:  " + c + " case: " + testCase);
			}
		}
		pass = p;
	}
}
