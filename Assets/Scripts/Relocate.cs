using UnityEngine;
using System.Collections;

public class Relocate : MonoBehaviour {

	private Transform transformRef;
	private Vector3 positionInside;
	private State myState;

	void Start()
	{
		transformRef = this.gameObject.transform;
		myState = this.gameObject.GetComponent ("State") as State;
	}

	void OnMouseDown()
	{
		positionInside = transformRef.position;
	}

	void OnMouseDrag()
	{
		Vector3 pos = Input.mousePosition;
		pos.z = 5;
		pos = Camera.main.ScreenToWorldPoint(pos);

		transformRef.position = pos;

		if (CreationArea.IsInsideCreationArea(this.gameObject.GetComponent ("Collider2D") as Collider2D)) {
			positionInside = transformRef.position;
		}

		myState.UpdateTransitionArrows ();
	}
	
	void OnMouseUp()
	{
		transformRef.position = positionInside;
		myState.UpdateTransitionArrows ();
	}
}
