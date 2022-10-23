using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAgares : MonoBehaviour
{
    public GameObject Player;
    private Vector3 posFinal;
    public float Vel;
    bool AgaresSube = false;

    private void Update()
    {
        posFinal = new Vector3 (transform.position.x, transform.position.y + 2f, transform.position.z);

        Vector3 direction = Player.transform.position - transform.position;
        if(direction.x >= 0.0f){
            GetComponent<SpriteRenderer>().flipX = true;
        } else GetComponent<SpriteRenderer>().flipX = false;

        if(AgaresSube){
            transform.position = Vector3.Lerp(transform.position, posFinal, Vel * Time.deltaTime);
            Invoke("Stop", 2.0f);
        }

    }

    public void OnBecameVisible(){
        Debug.Log("esta visible");
        AgaresSube = true;
    }

    void Stop(){
        AgaresSube = false;
    }
}
