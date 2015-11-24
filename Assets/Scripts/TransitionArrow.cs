using UnityEngine;
using System.Collections;

public class TransitionArrow : MonoBehaviour {

	public State start;
	public State end;
	public bool isOffset = false;
	public bool hasDuplicate = false;

	private SpriteRenderer arrowRenderer;
	
	public enum TransitionColor
	{
		yellow,
		blue
	}
	public TransitionColor myTransitionColor;

	public void OnMouseDown()
	{
		if (myTransitionColor == TransitionColor.blue)
			ColorArrow (TransitionColor.yellow);
		else
		{
			ColorArrow(TransitionColor.blue);
		}
	}

	
	public void Initialize(State s, State e, TransitionColor t, bool isOffset)
	{
		start = s;
		end = e;
		myTransitionColor = t;

		this.isOffset = isOffset;

		s.myTransitionsFrom.Add(this);
		e.myTransitionsTo.Add(this);

		arrowRenderer = this.gameObject.GetComponent ("SpriteRenderer") as SpriteRenderer;

		ColorArrow (t);

		this.hasDuplicate = isOffset;

		UpdateArrow ();

	}
	
	public void ColorArrow(TransitionColor t)
	{
		if (hasDuplicate)
			return;

		switch(t)
		{
		case TransitionColor.blue:
			myTransitionColor = TransitionColor.blue;
			arrowRenderer.color = new Color(.0f, 0.3f, .9f, 1f);
			break;
		case TransitionColor.yellow:
			myTransitionColor = TransitionColor.yellow;
			arrowRenderer.color = new Color(.8f, 0.7f, .3f, 1f);
			break;
		}
	}
	
	public void UpdateArrow()
	{
		RotateArrow ();
		PositionArrow (isOffset);
		ScaleArrow ();
	}
	
	private void ScaleArrow()
	{
		float scaleFactor = Mathf.Sqrt(Mathf.Pow((start.transform.position.x - end.transform.position.x),2) + Mathf.Pow ((start.transform.position.y - end.transform.position.y),2));
		Vector3 scale = new Vector3 (scaleFactor/10,this.gameObject.transform.localScale.y,1);
		this.gameObject.transform.localScale = scale;
	}
	
	private void PositionArrow(bool isOffset)
	{ 		
		Vector2 pos = new Vector2 ((start.transform.position.x + end.transform.position.x)/2, (start.transform.position.y + end.transform.position.y)/2);
		if (isOffset) {
			pos.x += .5f;
			pos.y += .5f;
		}
		this.gameObject.transform.position = pos;
	}
	
	private void RotateArrow()
	{
		Vector3 vectorToTarget = end.transform.position - start.transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		this.gameObject.transform.rotation = q;
	}
}
