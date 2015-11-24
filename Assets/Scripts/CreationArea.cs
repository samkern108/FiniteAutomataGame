using UnityEngine;
using System.Collections;

public class CreationArea : MonoBehaviour {

	private static Collider2D myCollider;

	void Start()
	{
		myCollider = this.gameObject.GetComponent ("Collider2D") as Collider2D;
	}

	public static bool IsInsideCreationArea(Collider2D other)
	{
		if (other.IsTouching (myCollider)) {
			return true;
		}
		return false;
	}
}
