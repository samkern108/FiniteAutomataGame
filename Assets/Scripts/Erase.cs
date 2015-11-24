using UnityEngine;
using System.Collections;

public class Erase : MonoBehaviour {

	public void ClearAll()
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag ("State");

		foreach(GameObject obj in objects)
		{
			Destroy (obj);
		}

		objects = GameObject.FindGameObjectsWithTag ("Transition");

		foreach(GameObject obj in objects)
		{
			Destroy (obj);
		}

		State.startState = null;
		DrawTransition.ClearAll ();
	}
}
