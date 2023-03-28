using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;
    public float speed = 5;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Update(){
        if(player){
        Vector3 targetPos = new Vector3(player.transform.position.x, 0.0f, player.transform.position.z);
        transform.LookAt(targetPos);
        if(Vector3.Distance(targetPos, transform.position) > CombatConfig.MIN_DISTANCE)
          transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
      }
    }
}
