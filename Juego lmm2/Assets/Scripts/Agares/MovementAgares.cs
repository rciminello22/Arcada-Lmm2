using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAgares : MonoBehaviour
{
    public GameObject Player;
    private Vector3 posFinal;
    public float Vel;
    bool AgaresSube = false;
    bool primeraVez = false;


    private void Start(){
        posFinal = new Vector3 (transform.position.x, transform.position.y + 4f, transform.position.z);
    }


    private void Update()
    {

        Vector3 direction = Player.transform.position - transform.position;
        if(direction.x >= 0.0f){
            GetComponent<SpriteRenderer>().flipX = true;
        } else GetComponent<SpriteRenderer>().flipX = false;

        if(AgaresSube){
            transform.position = Vector3.Lerp(transform.position, posFinal, Vel * Time.deltaTime);
            Invoke("Stop", 1.0f);
        }

        if(transform.position != posFinal){
            primeraVez = false;
        } else {
            primeraVez = true;
        }

    }

    public void OnBecameVisible(){
       if(primeraVez == false){
            //Debug.Log("esta visible");
            AgaresSube = true;
        }
    }

    void Stop(){
        AgaresSube = false;
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            col.gameObject.GetComponent<PlayerMovement>().TomarDaño(col.GetContact(0).normal);
        }
    }
}
