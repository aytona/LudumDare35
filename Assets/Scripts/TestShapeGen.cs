using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class TestShapeGen : MonoBehaviour {

	public int xSize, ySize;

	private Vector3[] vertices;
	private Vector2[] uv;
	private int[] triangles;
	private Mesh mesh;

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
		mesh = GetComponent<MeshFilter>().mesh;
		mesh.name = "Grid";

		vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		uv = new Vector2[vertices.Length];
		int i = 0;
		for (int y = 0; y <= ySize; y++) {
			for (int x = 0; x <= xSize; x++) {
				vertices[i] = new Vector3(x, y);
				uv[i] = new Vector2(x/xSize, y/ySize);
				i++;
			}
		}
		mesh.vertices = vertices;
		mesh.uv = uv;

		triangles = new int[xSize * ySize * 6];
		for (int ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
			for (int x = 0; x < xSize; x++, ti += 6, vi++) {
				triangles[ti] = vi;
				triangles[ti + 3] = triangles[ti + 2] = vi + 1;
				triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
				triangles[ti + 5] = vi + xSize + 2;
			}
		}
		mesh.triangles = triangles;
	}
}
