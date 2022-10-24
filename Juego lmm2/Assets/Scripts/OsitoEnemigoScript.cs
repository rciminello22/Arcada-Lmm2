using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsitoEnemigoScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject BalaPrefab;
    private float UltimoDisparo;
    Animator animator;
    Vector2 Infinito;
    public float LiberacionVel;

    private bool Liberado = false;


    void Start(){
        animator = GetComponent<Animator>();
        Infinito = new Vector2 (transform.position.x - 20, transform.position.y);
    }

    private void Update()
    {
        if(!Liberado){

            Vector3 direction = Player.transform.position - transform.position;
            if(direction.x >= 0.0f){
                GetComponent<SpriteRenderer>().flipX = true;
                BalaPrefab.GetComponent<SpriteRenderer>().flipX = true;
            } else {
                    GetComponent<SpriteRenderer>().flipX = false;
                    BalaPrefab.GetComponent<SpriteRenderer>().flipX = false;
                }
            
            float directionXNohi = Player.transform.position.x;
            float directionXEnemigo = transform.position.x - 7;

            if(directionXNohi >= directionXEnemigo && directionXNohi < directionXEnemigo + 14 && Time.time > UltimoDisparo + 1) 
            {
                Shoot();
                UltimoDisparo = Time.time;
            }
        }

        if(Liberado){
            transform.position = Vector2.Lerp(transform.position, Infinito, LiberacionVel * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }

    }

    private void Shoot()
    {
        Vector3 direction;
        if(GetComponent<SpriteRenderer>().flipX == true)
        {
            direction = Vector2.right;
        } else direction = Vector2.left; 

        GameObject Bala = Instantiate(BalaPrefab, transform.position + direction * 0.3f, Quaternion.identity);
        Bala.GetComponent<BalaScript>().SetDirection(direction);
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.CompareTag("Player")){
            foreach (ContactPoint2D punto in col.contacts){
                if(punto.normal.y <= -0.9){
                    Liberado = true;
                    animator.SetBool("running", true);
                }
            }
            /*if(col.GetContact(0).normal.y <= -0.9){
                Liberado = true;
                animator.SetBool("running", true);
            }*/
        }
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
