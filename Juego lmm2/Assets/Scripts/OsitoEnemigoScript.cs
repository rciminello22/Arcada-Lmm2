using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OsitoEnemigoScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject BalaPrefab;
    private float UltimoDisparo;

    private void Update()
    {
        Vector3 direction = Player.transform.position - transform.position;
        if(direction.x >= 0.0f){
        GetComponent<SpriteRenderer>().flipX = true;
        } else GetComponent<SpriteRenderer>().flipX = false;
        
        float directionXNohi = Player.transform.position.x;
        float directionXEnemigo = transform.position.x - 7;

        if(directionXNohi >= directionXEnemigo && directionXNohi < directionXEnemigo + 14 && Time.time > UltimoDisparo + 1) 
        {
            Shoot();
            UltimoDisparo = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 direction;
        if(GetComponent<SpriteRenderer>().flipX == true)
        {
            direction = Vector2.right;
        } else direction = Vector2.left; 

        GameObject Bala = Instantiate(BalaPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        Bala.GetComponent<BalaScript>().SetDirection(direction);
    }
}
