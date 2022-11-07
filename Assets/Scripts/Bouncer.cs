using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//outline:
/*
 * If object hits [the ground, wall, or other objects], then add time to the timer and richochet/bounce.
 */

public class Bouncer : MonoBehaviour
{
    private Rigidbody2D rb;
    Vector3 velocity;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        velocity = new Vector3(5f, 5f, 0f); //5f, 5f are arbitrary place holders.
        speed = 10f;

    }

    //https://www.youtube.com/watch?v=Vr-ojd4Y2a4  watch with sound

    // Update is called once per frame
    void Update()
    {
        //this.transform.position += velocity * Time.deltaTime * speed;
    }


    //https://www.youtube.com/watch?v=Vr-ojd4Y2a4
    private void OnCollisionEnter2D(Collision2D other)
    {
        //if other.tag == a tag of a wall or sometrhing, then reflect

        if(other.gameObject.CompareTag("Ground"))        // || other.gameObject.CompareTag( other tags that allows reflection )
        {
            Vector2 wallNormal = other.contacts[0].normal;
        }
    }
}
