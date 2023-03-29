using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : ScriptableObject{
  public List<Tile> tiles = new List<Tile>();
  public Tile TileOfType(TileType tileType){
    return tiles[(int)tileType];
  }
}

