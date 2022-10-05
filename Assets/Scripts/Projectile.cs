using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float movement = .5f;
    public GameObject parent;
    public int travelFrames = 1;

    private int framesTaveled = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(movement, 0 , 0);


        framesTaveled++;
        //despawn bullet after distance
        if(framesTaveled > travelFrames)
        {
            Destroy(gameObject);
            //Debug.Log("despawning bullet!");
        }
        
        
    }
    //   private void OnCollisionEnter2D(Collision2D collision)
    //   {
    //       if(collision.gameObject!= parent)
    //           Destroy(gameObject);
    //  }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("wanting to collided!");
        if (collision.gameObject != parent)
        {
            Destroy(gameObject);
            Debug.Log("colliding!");
        }
    }

}
