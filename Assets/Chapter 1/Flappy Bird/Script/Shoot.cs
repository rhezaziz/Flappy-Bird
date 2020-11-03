using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    float speed = 20f;
    public Rigidbody2D rg;

    private void Start()
    {
        rg.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("pipeDown") || collision.gameObject.CompareTag("pipeUp"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }

        if(collision.gameObject.CompareTag("Batas")|| collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        //Memusnahkan object ketika bersentuhan
        
    }
}
