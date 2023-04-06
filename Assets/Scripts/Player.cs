using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, PlayerControls.IMouseActions{
  PlayerControls inputs;
  public HexGrid hexGrid;
  int activeElevation = 1;
  public Color defaultColor = Color.white;

  public void OnClick(InputAction.CallbackContext context){
    Vector3 pos = Mouse.current.position.ReadValue();
    Ray inputRay = Camera.main.ScreenPointToRay(pos);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
      EditCell(hexGrid.GetCell(hit.point));
		}
  }

  void EditCell(HexCell cell) {
    cell.color = HexMetrics.activeColor;
    cell.Elevation += activeElevation;
    cell.transform.localPosition += new Vector3(0, cell.Elevation, 0);
		hexGrid.Refresh();
	}

  private void Awake(){
    hexGrid = GameObject.Find("HexGrid").GetComponent<HexGrid>();
    inputs = new PlayerControls();
    inputs.Mouse.Click.performed += OnClick;
    inputs.Enable();
  }
}
