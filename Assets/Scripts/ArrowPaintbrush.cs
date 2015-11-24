using UnityEngine;
using System.Collections;

public class ArrowPaintbrush : MonoBehaviour {
	
	private GameObject collidingObject;
	public TransitionArrow.TransitionColor myBrushColor;
	
	public void Repaint()
	{
		if (collidingObject != null) {
			Debug.Log ("Beep Doop Boop");
			TransitionArrow s = collidingObject.GetComponent("TransitionArrow") as TransitionArrow;
			s.ColorArrow(myBrushColor);
		}
		Destroy (this.gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D coll) 
	{
		Debug.Log (coll.tag);
		if (coll.gameObject.tag == "Transition") {
			Debug.Log ("?");
			collidingObject = coll.gameObject;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Transition") {
			collidingObject = null;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		Debug.Log (coll.gameObject.tag);
	}

	void OnCollisionExit2D(Collision2D coll) {
		Debug.Log (coll.gameObject.tag);
	}
}
