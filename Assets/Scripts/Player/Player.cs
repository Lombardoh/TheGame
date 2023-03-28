using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour, PlayerControls.IPlayerInputActions
{

  PlayerControls inputs;
  private Vector3 movement;
  public float speed = 3;
  public float turnRate = 5;
  Camera mainCam;
  [SerializeField] GameObject tile;
  public GameObject cube;
  public GameObject target;

  public void Move(Vector3 target){
    transform.Translate(movement * speed * Time.deltaTime);
  }

  public void OnMovement(InputAction.CallbackContext context){
    movement = context.ReadValue<Vector3>();
    if (context.canceled)
        movement = Vector3.zero;

  }

  public void OnAttack(InputAction.CallbackContext context){
    Debug.Log("Attack");
    if(context.performed){
    }
  }

  public void OnMouse(InputAction.CallbackContext context){
    if(context.performed){
      RaycastHit hit;
      Vector3 mousePos = Mouse.current.position.ReadValue();

      Ray ray = mainCam.ScreenPointToRay(mousePos);
      if (Physics.Raycast(ray, out hit)){
        target = Instantiate(cube, hit.point + new Vector3(0, 0.2f, 0), Quaternion.identity);
      }
    }
  }
  public void OnPointer(InputAction.CallbackContext context){
      // Vector3 mousePos = Mouse.current.position.ReadValue();   
      // Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);  
      // Debug.Log(Worldpos);
  }

  private void Awake() {
    mainCam = Camera.main;
    mainCam.enabled = true;
    inputs = new PlayerControls();
    inputs.PlayerInput.Movement.performed += OnMovement;    
    inputs.PlayerInput.Movement.canceled += OnMovement;    
    inputs.PlayerInput.Attack.performed += OnAttack;    
    inputs.PlayerInput.Attack.canceled += OnAttack;    
    inputs.PlayerInput.Mouse.performed += OnMouse;    
    inputs.PlayerInput.Mouse.canceled += OnMouse;    
 
  }

    private void Update() {
      if(target){
        Vector3 targetPos = new Vector3(target.transform.position.x, 0.0f, target.transform.position.z);
        transform.LookAt(targetPos);
        if(Vector3.Distance(targetPos, transform.position) > CombatConfig.MIN_DISTANCE)
          transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
      }
    }

  private void OnEnable(){
     inputs.PlayerInput.Enable();
  }
  private void OnDisable(){    
     inputs.PlayerInput.Disable();
  }

}
