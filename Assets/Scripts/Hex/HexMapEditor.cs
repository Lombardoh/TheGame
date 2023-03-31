using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HexMapEditor : MonoBehaviour, PlayerControls.IMouseActions{
	public Color[] colors;
	public HexGrid hexGrid;
	private Color activeColor;
  public PlayerControls controls;

  public void OnClick(InputAction.CallbackContext context){
    Ray inputRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
		RaycastHit hit;
    Debug.Log("asd");
		if(Physics.Raycast(inputRay, out hit)) {
			hexGrid.ColorCell(hit.point, Color.white);
    }
  }

	void Awake () {
		SelectColor(0);
    controls = new PlayerControls();
    controls.Mouse.Click.performed += OnClick;
    controls.Enable();
	}

  public void SelectColor (int index) {
		activeColor = colors[index];
	}
}
