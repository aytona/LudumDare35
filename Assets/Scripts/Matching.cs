using UnityEngine;
using System.Collections;

public class Matching : MonoBehaviour {

	// Simple matching

	public string[] ShapeNames;

	private string requiredShapeName;
	private bool waitingForMatch = true;

	void Update() {
		if (waitingForMatch) {
			PickRandomShape();
		}

		if (Input.GetMouseButtonDown (0)) {

		}
	}

	private void PickRandomShape() {
		requiredShapeName = ShapeNames [Random.Range(0, ShapeNames.Length)];
		waitingForMatch = false;
	}
}