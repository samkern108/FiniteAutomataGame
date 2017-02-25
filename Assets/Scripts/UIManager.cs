using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject goalTextObject;
	public GameObject statusButtonObject;
	public GameObject statusButtonTextObject;

	private Text goalText;
	private Text statusText;
	public static UIManager instance;

	void Awake()
	{
		instance = this;
		goalText = goalTextObject.GetComponent ("Text") as Text;
		statusText = statusButtonTextObject.GetComponent ("Text") as Text;

		goalText.text = "";
		statusText.text = "";
		statusButtonObject.SetActive (false);
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
