using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraScript : MonoBehaviour
{

    public GameObject Player;
    FabricaScript fabrica;
    PlayerMovement playerMovement;
    private Vector3 TargetPos;
    Camera cam;
    public float HaciaDelante;
    public float Smoothing;

    private bool ZoomActive;
    public float Speed;

    void Start()
    {
        cam = FindObjectOfType<Camera>();
        fabrica = FindObjectOfType<FabricaScript>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        TargetPos = new Vector3 (Player.transform.position.x, Player.transform.position.y, transform.position.z);

        if(playerMovement.Horizontal == 1){
            TargetPos = new Vector3 (TargetPos.x + HaciaDelante, TargetPos.y, transform.position.z);
        } 
        else if(playerMovement.Horizontal == -1){
            TargetPos = new Vector3 (TargetPos.x - HaciaDelante, TargetPos.y, transform.position.z);
        }

        transform.position = Vector3.Lerp (transform.position, TargetPos, Smoothing * Time.deltaTime);

        if(fabrica.EstasEnLaFabrica){
            ZoomActive = true;
        } else {
            ZoomActive = false;
        }
    }

    void LateUpdate(){

        if(ZoomActive){
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 7 , Speed); 
        } else {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 3.5f , Speed);
        }

    }
}
