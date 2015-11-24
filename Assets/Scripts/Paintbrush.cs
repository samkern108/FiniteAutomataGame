using UnityEngine;
using System.Collections;

public class Paintbrush : MonoBehaviour {

	private GameObject collidingObject;
	public enum brushType {accept, reject, start};
	public brushType myBrushType;

	public void Repaint()
	{
		if (collidingObject != null) {
			State s = collidingObject.GetComponent("State") as State;
			s.Repaint(myBrushType);
		}
		Destroy (this.gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "State") {
			collidingObject = coll.gameObject;
		}
	}
	
	void OnTriggerExit2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "State") {
			collidingObject = null;
		}
	}
}
