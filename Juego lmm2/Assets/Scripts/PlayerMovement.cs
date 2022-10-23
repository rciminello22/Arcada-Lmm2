using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CapsuleCollider2D player;
    public GameObject bala;
    PlayerRespawnScript respawn;
    public float Speed;
    public float JumpForce;
    Vector2 Checkpoint;

    private Animator Animator;
    private Rigidbody2D Rigidbody2D;
    public float Horizontal;
    private bool Grounded;
    private bool Agachado;
    public float RespawnVel = 1.0f; 

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        player = player.GetComponent<CapsuleCollider2D>();
        Animator = GetComponent<Animator>();
        respawn = FindObjectOfType<PlayerRespawnScript>();

    }

    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Agachado = Input.GetKey(KeyCode.S);

        Animator.SetBool("running", Horizontal != 0.0f);
        Animator.SetBool("Agachado", Agachado);

        if(Agachado)
        {
            player.offset = new Vector2 (player.offset.x, 1.511268f);
            player.size = new Vector2 (player.size.x, 5.119489f);
        } else {
            player.offset = new Vector2 (player.offset.x, -0.09209903f);
            player.size = new Vector2 (player.size.x, 7.957828f);
        }

        if(Input.GetKeyDown(KeyCode.W)&& Grounded)
        {
            Grounded = false;
            Jump();
        }

    }

    private void Jump()
    {
      //Rigidbody2D.AddForce(Vector2.up * JumpForce);
      Rigidbody2D.AddForce(new Vector2(0f, JumpForce),ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {

        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        if(Horizontal == -1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        } else if (Horizontal == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "ground")
        {
            Grounded = true;
        } else if (collision.transform.tag == "platform"){
            Grounded = true;
        } else if (collision.transform.tag == "fabrica"){
            Grounded = true;
        } else if (collision.transform.tag == "Agares"){
            Invoke("Respawnear", 0.5f);
        }
    }

    void Respawnear(){
        respawn.RespawnPlayer();
        //
    }
}
