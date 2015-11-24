using UnityEngine;
using System.Collections;

public class BrushSpawner : MonoBehaviour {
	
	public GameObject spawnPrefab;
	private GameObject instantiatedObject;
	public enum Brush {state, arrow};
	public Brush myBrushType;
	bool haveState = false;
	
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

		switch(myBrushType)
		{
		case Brush.arrow:
			ArrowPaintbrush apb = instantiatedObject.GetComponent("ArrowPaintbrush") as ArrowPaintbrush;
			apb.Repaint();
			break;
		case Brush.state:
			Paintbrush pb = instantiatedObject.GetComponent ("Paintbrush") as Paintbrush;
			pb.Repaint ();
			break;
		}
	}
}
