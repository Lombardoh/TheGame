using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid{
  private int width;
  private int height;
  private float cellSize;
  private int[,] gridArray;
  GameObject gameManager;

  public Grid(int width, int height, float cellSize){
    this.width = width;
    this.height = height;
    this.cellSize = cellSize;
    gridArray = new int[width, height];
    gameManager = GameObject.Find("GameManager");

    for(int x= 0; x < gridArray.GetLength(0); x++){
      for(int y= 0; y < gridArray.GetLength(1); y++){
        CreateWorldText(gridArray[x,y].ToString(), gameManager.transform, GetWorldPosition(x,y) + new Vector3(cellSize, 0, cellSize) * .5f, Color.white, 40);
        Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x, y + 1), Color.white, 100f);
        Debug.DrawLine(GetWorldPosition(x,y), GetWorldPosition(x +1 , y), Color.white, 100f);
      }
    }

    Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white, 100f);
    Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white, 100f);
    
  }

  public static TextMesh CreateWorldText(string text, Transform parent, Vector3 localPos, Color color, int fontSize){
  if(color == null) color = Color.white;
  GameObject gameObject = new GameObject("World_text", typeof(TextMesh));
  Transform transform = gameObject.transform;
  transform.SetParent(parent, false);
  transform.localPosition = localPos;
  transform.eulerAngles = new Vector3(90, 0, 0);
  TextMesh textMesh = gameObject.GetComponent<TextMesh>();
  textMesh.text = text;
  textMesh.fontSize = fontSize;
  textMesh.color = color;
  
  return textMesh;
  }

  private Vector3 GetWorldPosition(int x, int z){
    return new Vector3(x, 0 ,z) * cellSize;
  }
}
