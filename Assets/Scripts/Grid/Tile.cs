using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tile{
  public string name;
  public GameObject prefab;
  public TileType tileType;
  
  private int width;
  private int height;
  private float tileSize;

  public Tile(int width, int height, float tileSize){
    this.width = width;
    this.height = height;
    this.tileSize = tileSize;

  }
}
