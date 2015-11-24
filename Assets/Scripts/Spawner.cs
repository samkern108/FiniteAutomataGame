using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject spawnPrefab;
	private GameObject instantiatedObject;
	bool haveState = false;
	public State.type mySpawnType;

	void OnMouseDrag() 
	{
		if (!haveState) {	
			haveState = true;
			instantiatedObject = Instantiate(spawnPrefab);
		}
		
		Vector3 pos = Input.mousePosition;
		pos.z = 5;
		pos = Camera.main.ScreenToWorldPoint(pos);
		
		instantiatedObject.transform.position = pos;
	}

	void OnMouseUp()
	{
		haveState = false;
		
		if (!CreationArea.IsInsideCreationArea (instantiatedObject.GetComponent ("Collider2D") as Collider2D)) {
			Destroy (instantiatedObject);
		} else {
			State s = instantiatedObject.GetComponent("State") as State;
			s.SetType (mySpawnType);
		}
	}

}
