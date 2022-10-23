using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnScript : MonoBehaviour
{
    public float CheckPointPositionX, CheckPointPositionY;

    public void CheckPointReached(float x, float y){

        PlayerPrefs.SetFloat("CheckPointPositionX", x);
        PlayerPrefs.SetFloat("CheckPointPositionY", y);
    }

    private void OnTriggerEnter2D(Collider2D col){

        if(col.gameObject.CompareTag("deathzone")){
            Invoke ("RespawnPlayer", 1.0f);
        }
    }

    public void RespawnPlayer(){
        transform.position = (new Vector2 (PlayerPrefs.GetFloat("CheckPointPositionX"), PlayerPrefs.GetFloat("CheckPointPositionY")));
    }
}

