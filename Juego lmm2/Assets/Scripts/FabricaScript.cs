using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricaScript : MonoBehaviour
{

    public bool EstasEnLaFabrica = false;

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            EstasEnLaFabrica = true;
        }
    }

}
