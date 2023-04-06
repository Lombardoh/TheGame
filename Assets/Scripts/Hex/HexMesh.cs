using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexMesh : MonoBehaviour {
  MeshCollider meshCollider;
	Mesh hexMesh;
	List<Vector3> vertices;
	List<int> triangles;
  List<Color> colors;

	void Awake () {
		GetComponent<MeshFilter>().mesh = hexMesh = new Mesh();
    meshCollider = gameObject.AddComponent<MeshCollider>();
		hexMesh.name = "Hex Mesh";
		vertices = new List<Vector3>();
		triangles = new List<int>();
    colors = new List<Color>();
	}

  public void Triangulate (HexCell[] cells) {
		hexMesh.Clear();
		vertices.Clear();
		triangles.Clear();
    colors.Clear();
		for (int i = 0; i < cells.Length; i++) {
			Triangulate(cells[i]);
		}
		hexMesh.vertices = vertices.ToArray();
		hexMesh.triangles = triangles.ToArray();
    hexMesh.colors = colors.ToArray();
		hexMesh.RecalculateNormals();
    meshCollider.sharedMesh = hexMesh;
	}

	void Triangulate (HexCell cell) {
		for (HexDirection d = HexDirection.NE; d <= HexDirection.NW; d++) {
			Triangulate(d, cell);
		}
  }

  void Triangulate(HexDirection direction, HexCell cell){
		Vector3 center = cell.transform.localPosition;
    Vector3 v1 = center + HexMetrics.GetFirstCorner(direction);
		Vector3 v2 = center + HexMetrics.GetSecondCorner(direction);
    AddTriangle(center, v1, v2);
    if(center.y >=8){
		  AddTriangleColor(Color.grey);
    }
    else if(center.y >=4){
		  AddTriangleColor(Color.green);
    }else{
      AddTriangleColor(Color.blue);
    }

		Vector3 v3 = v1;
		Vector3 v4 = v2;

    HexCell prevNeighbor = cell.GetNeighbor(direction.Previous()) ?? cell;
		HexCell neighbor = cell.GetNeighbor(direction) ?? cell;
		HexCell nextNeighbor = cell.GetNeighbor(direction.Next()) ?? cell;

    v3.y = v4.y = neighbor.Elevation * HexMetrics.elevationStep;
		AddQuad(v1, v2, v3, v4);
    AddQuadColor(Color.cyan, Color.cyan);
  }

  void AddTriangleColor(Color color) {
		colors.Add(color);
		colors.Add(color);
		colors.Add(color);
	}

  void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3) {
		int vertexIndex = vertices.Count;
		vertices.Add(v1);
		vertices.Add(v2);
		vertices.Add(v3);
		triangles.Add(vertexIndex);
		triangles.Add(vertexIndex + 1);
		triangles.Add(vertexIndex + 2);
	}

  void AddQuad (Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4) {
		int vertexIndex = vertices.Count;
		vertices.Add(v1);
		vertices.Add(v2);
		vertices.Add(v3);
		vertices.Add(v4);
		triangles.Add(vertexIndex);
		triangles.Add(vertexIndex + 2);
		triangles.Add(vertexIndex + 1);
		triangles.Add(vertexIndex + 1);
		triangles.Add(vertexIndex + 2);
		triangles.Add(vertexIndex + 3);
	}
	void AddQuadColor (Color c1, Color c2) {
		colors.Add(c1);
		colors.Add(c1);
		colors.Add(c2);
		colors.Add(c2);
	}
}