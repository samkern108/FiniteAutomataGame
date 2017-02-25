using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandbox : MonoBehaviour {

	private GameObject statePrefab;

	void Start() {
		statePrefab = ResourceLoader.LoadPrefab (ResourceNamePrefab.StatePrefab);
	}

	void Update() {
		if (Input.GetMouseButtonDown (0)) {
			SpawnState ();
		}
	}

	private void SpawnState() {
		State state = Instantiate (statePrefab).GetComponent<State>();
		state.SetType (State.type.accept);
		state.transform.position = Camera.main.ScreenToWorldPoint (Input.mousePosition);
	}
}
