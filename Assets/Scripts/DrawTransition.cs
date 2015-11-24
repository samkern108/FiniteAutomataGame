using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawTransition : MonoBehaviour {
	
	private static bool drawingState = false;

	private static State startState;
	private static State endState;

	public GameObject transitionArrowPrefab;
	private GameObject arrowObject;

	public static void ClearAll()
	{
		startState = null;
		endState = null;
	}
	
	void OnMouseOver () 
	{
		if (Input.GetMouseButtonDown (1)) {
			if(!drawingState) {
				startState = this.gameObject.GetComponent("State") as State;
				startState.SetSelected(true);
			}
			else {
				startState.SetSelected(false);
				endState = this.gameObject.GetComponent("State") as State;

				if(startState == endState){
					return;
				}

				int toEndState = 0;
				TransitionArrow referenceToDuplicate = null;
				TransitionArrow.TransitionColor taColor = TransitionArrow.TransitionColor.yellow;
				bool isOffset = false;

				foreach(TransitionArrow ta in startState.myTransitionsFrom){
					if(ta.end == endState) {
						referenceToDuplicate = ta;
						toEndState++;
						endState.myTransitionsTo[endState.myTransitionsTo.IndexOf(ta)].hasDuplicate = true;
					}
				}

				if(toEndState >= 2) {
					return;
				}
				else if(toEndState == 1) {
					if(referenceToDuplicate.myTransitionColor == TransitionArrow.TransitionColor.yellow) {
						taColor = TransitionArrow.TransitionColor.blue;
						isOffset = true;
					}
				}

				GameObject arrowObject = Instantiate(transitionArrowPrefab);
				TransitionArrow arrow = arrowObject.GetComponent("TransitionArrow") as TransitionArrow;
				arrow.Initialize(startState, endState, taColor, isOffset);
			}
			drawingState = !drawingState;
		}
	}
}