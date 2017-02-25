using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class State : MonoBehaviour {

	public enum type {accept, reject};
	public static State startState;
	public type myType;
	private SpriteRenderer myRenderer;

	public GameObject startArrowPrefab;
	private GameObject startArrowObject; 

	public List<TransitionArrow> myTransitionsTo;
	public List<TransitionArrow> myTransitionsFrom;

	public void UpdateTransitionArrows()
	{
		foreach (TransitionArrow stt in myTransitionsTo) {
			stt.UpdateArrow();
		}

		foreach (TransitionArrow stf in myTransitionsFrom) {
			stf.UpdateArrow();
		}
	}

	void Start () {
		myTransitionsFrom = new List<TransitionArrow> ();
		myTransitionsTo = new List<TransitionArrow> ();

		if (startState == null) {
			SetStart ();
		}

		myRenderer = this.gameObject.GetComponent ("SpriteRenderer") as SpriteRenderer;
	}

	public void SetType(type t)
	{
		myType = t;

		switch (t) {
		case type.accept:
			myRenderer.color = Palette.customGreen;
			break;
		case type.reject:
			myRenderer.color = Palette.customRed;
			break;
		}
	}

	public void Repaint(Paintbrush.brushType t)
	{
		switch (t) {
		case Paintbrush.brushType.accept:
			SetType(type.accept);
			break;
		case Paintbrush.brushType.reject:
			SetType (type.reject);
			break;
		case Paintbrush.brushType.start:
			SetStart();
			break;
		}
	}

	private void SetStart()
	{
		if (!startArrowObject) {
			startArrowObject = Instantiate(startArrowPrefab) as GameObject;
		}
		startState = this;
		Vector3 startArrowPosition = this.gameObject.transform.position;
		startArrowPosition.x -= 1.5f;
		startArrowObject.transform.position = startArrowPosition;
		startArrowObject.transform.parent = this.transform;
	}

	public void SetSelected(bool selected)
	{
		if (selected) {
			float myScale = .45f;
			this.gameObject.transform.localScale = new Vector3(myScale, myScale, myScale);
		} else {
			float myScale = .25f;
			this.gameObject.transform.localScale = new Vector3(myScale, myScale, myScale);
		}
	}
}
