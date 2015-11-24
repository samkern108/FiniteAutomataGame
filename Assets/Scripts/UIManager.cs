using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject goalTextObject;
	public GameObject statusButtonObject;
	public GameObject statusButtonTextObject;
	public GameObject instructionsPanel;
	public GameObject examplePanel;

	private Text goalText;
	private Text statusText;
	public static UIManager instance;

	private bool instructionsVisible = false;
	private bool examplePanelVisible = false;

	void Start()
	{
		instance = this;
		goalText = goalTextObject.GetComponent ("Text") as Text;
		statusText = statusButtonTextObject.GetComponent ("Text") as Text;

		goalText.text = "";
		statusText.text = "";
		instructionsPanel.SetActive (instructionsVisible);
		statusButtonObject.SetActive (false);
		examplePanel.SetActive (examplePanelVisible);
	}

	public void ToggleInstructionsPanel()
	{
		instructionsVisible = !instructionsVisible;
		instructionsPanel.SetActive (instructionsVisible);
	}

	public void ToggleExamplePanel()
	{
		examplePanelVisible = !examplePanelVisible;
		examplePanel.SetActive (examplePanelVisible);
	}

	public void UpdateGoalText(string gt)
	{
		goalText.text = gt;
	}

	public void UpdateStatusText(string st)
	{
		statusButtonObject.SetActive (true);
		statusText.text = st;
	}
}
