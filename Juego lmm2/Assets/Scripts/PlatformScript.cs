using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    private Rigidbody2D Rigidbody2D;
    private BoxCollider2D box;
    private PlatformEffector2D platform;
    public float Timer = 0f;
    private bool readyToShake = false;

    public float shakeAmount = 16f;
    public float fallDelay = 0.8f;
    bool PlatformMovingBack = false;

    Vector3 originalPos;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        platform = GetComponent<PlatformEffector2D>();
    }


    void Update()
    {

       Timer = Timer + Time.deltaTime;

        if(Timer >= 6f)
        {
            StartCoroutine(Falling(fallDelay));
            Timer = 0;
        }

        if(readyToShake)
        {
            Vector3 newPos = originalPos + Random.insideUnitSphere * (Time.deltaTime * shakeAmount);
            newPos.y = transform.position.y;
            newPos.z = transform.position.z; 
            transform.position = newPos;
        } 

        if(PlatformMovingBack)
        {
            readyToShake = false;
            transform.position = Vector2.MoveTowards (transform.position, originalPos, 20f * Time.deltaTime);
            platform.useOneWay = false;
        }
        if(transform.position.y == originalPos.y)
        {
            PlatformMovingBack = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("fabrica"))
        {
            gameObject.SetActive(false);
        }
    }

    IEnumerator Falling(float delay){

        originalPos = transform.position;

        yield return new WaitForSeconds(delay);

        readyToShake = true;

        yield return new WaitForSeconds(1.0f);

        Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;

        platform.useOneWay = true;

        Invoke ("GetPlatformBack", 3.0f);
    }

    void GetPlatformBack()
    {
        Rigidbody2D.velocity = Vector2.zero;
        Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        PlatformMovingBack = true;
    }

    void OnDisable(){
        Invoke ("SetActive", 3.0f);
    }

    void SetActive()
    {
        gameObject.SetActive(true);
    }

}

