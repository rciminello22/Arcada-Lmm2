using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col){

        if(col.CompareTag("Player")){
            col.GetComponent<PlayerRespawnScript>().CheckPointReached(transform.position.x, transform.position.y);
        }

    }

}
