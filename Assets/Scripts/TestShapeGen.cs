using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TestShapeGen : MonoBehaviour {

	public int xSize, ySize;

	private Vector3[] vertices;

	void Awake() {
		GenerateShape();
	}

	void OnDrawGizmos() {
		if (vertices == null) {
			return;
		}

		Gizmos.color = Color.black;
		for (int i = 0; i < vertices.Length; i++) {
			Gizmos.DrawSphere(vertices[i], 0.1f);
		}
	}

	private void GenerateShape() {
		vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		int i = 0;
		for (int y = 0; y <= ySize; y++) {
			for (int x = 0; x <= xSize; x++) {
				vertices[i] = new Vector3(x, y);
				i++;
			}
		}
	}
}
