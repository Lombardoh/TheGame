using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, PlayerControls.IMouseActions{
  PlayerControls inputs;
  public HexGrid hexGrid;

  public void OnClick(InputAction.CallbackContext context){
    Vector3 pos = Mouse.current.position.ReadValue();
    Ray inputRay = Camera.main.ScreenPointToRay(pos);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit)) {
			TouchCell(hit.point);
		}
  }

  void TouchCell(Vector3 position){
		position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);
    hexGrid.updateCell(coordinates);
  }

  private void Awake(){
    hexGrid = GameObject.Find("HexGrid").GetComponent<HexGrid>();
    inputs = new PlayerControls();
    inputs.Mouse.Click.performed += OnClick;
    inputs.Enable();
  }
}
