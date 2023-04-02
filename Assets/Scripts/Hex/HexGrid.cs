using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HexGrid : MonoBehaviour, PlayerControls.IMouseActions
{
  [SerializeField]
  private int width, height;
  public GameObject hexCellPrefab;
  public GameObject cubePrefab;
  private GameObject cube;
  private Vector3 position;
  private PlayerControls inputs;
  public Vector2 currentCell;
  public int steps;
  public float roundingCorrector;

  public void OnClick(InputAction.CallbackContext context){
    Vector3 mousePos = Mouse.current.position.ReadValue();   
    Ray ray = Camera.main.ScreenPointToRay(mousePos);  
    RaycastHit hit;
    if(Physics.Raycast(ray, out hit)){
      Vector2 newCell = hit.collider.gameObject.GetComponent<HexCell>().GetCurrentCell();
      Debug.Log("distance: " + Vector2.Distance(currentCell,newCell) + " " + hit.collider.gameObject.name);
      Debug.Log("threshold: " + Mathf.Sqrt(3) * HexConfiguration.size * steps);
      if(Vector2.Distance(currentCell, newCell) <= Mathf.Sqrt(3) * HexConfiguration.size * steps + roundingCorrector){
        cube.transform.localPosition = hit.collider.gameObject.GetComponent<HexCell>().GetPos() + new Vector3(0, 1.5f,0);
        currentCell = newCell;
      }
    }
  }

  private void Awake(){
    steps = 2;
    roundingCorrector = 0.1f;
    inputs = new PlayerControls();
    cube = new GameObject();
    cube = Instantiate<GameObject>(cubePrefab);
    inputs.Mouse.Click.performed += OnClick;
    inputs.Mouse.Enable();
    GenerateGrid();

  }

  public void GenerateGrid(){
    for(int x = 0; x < width; x++){
      for(int z = 0; z < height; z++){
        position.x = (x + z * 0.5f - z / 2) * Mathf.Sqrt(3) * HexConfiguration.size;
        position.z = z * HexConfiguration.size * 3/2;
        position.y = Random.Range(-1, 1);
        GameObject obj = Instantiate<GameObject>(hexCellPrefab);
        HexCell hexCell = obj.GetComponent<HexCell>();
        hexCell.Init(position.x, position.y, position.z, x, z);
        obj.transform.SetParent(transform, false);
        obj.transform.localPosition = new Vector3(position.x, position.y, position.z);
        if(x == width/2 && z == height/2){
            currentCell = obj.GetComponent<HexCell>().GetCurrentCell();
            cube.transform.localPosition = new Vector3(position.x, position.y + 1.5f, position.z);
        }
      }
    }
  }
}
