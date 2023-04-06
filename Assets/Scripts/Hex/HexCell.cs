using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexCell : MonoBehaviour{
	[SerializeField]
	public HexCell[] neighbors;

  public int Elevation{
    get{
      return elevation;
    }
    set{
      elevation = value;
      Vector3 position = transform.localPosition;
      position.y = value * HexMetrics.elevationStep;
      transform.localPosition = position;
    }
  }

  public int elevation;
  public HexCoordinates coordinates;
  public Color color;

  public HexCell GetNeighbor (HexDirection direction) {
		return neighbors[(int)direction];
	}

  public void SetNeighbor (HexDirection direction, HexCell cell) {
		neighbors[(int)direction] = cell;
    cell.neighbors[(int)direction.Opposite()] = this;
	}
}
