using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTile : MonoBehaviour
{
  public TileData tileData;
  public Transform[] positions;

  private void Start(){
    Debug.Log("Start");
    for(int x = 0; x < positions.Length; x++){
      GameObject tile = Instantiate(tileData.TileOfType((TileType) x).prefab, positions[x]);
      tile.transform.localPosition = Vector3.zero;
    }
  }
}
