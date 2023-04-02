using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based on a gameobject measured 2, 1.73, 2

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexCell : MonoBehaviour {
  private float posX, posY, posZ;
  private int x, z;

  void Awake(){
    Mesh mesh = GetComponent<MeshFilter>().mesh;
    Vector3 size = mesh.bounds.size;
  }

  public void Init(float posX, float posY, float posZ, int x, int z){
    this.posX = posX;
    this.posY = posY;
    this.posZ = posZ;
    this.x = x;
    this.z = z;
    transform.name = x.ToString() + " " + z.ToString();
  }

  public Vector3 GetPos(){
    return new Vector3(posX, posY, posZ);
  }

  public Vector3 GetCurrentCell(){
    return new Vector2(posX, posZ);
  }
}