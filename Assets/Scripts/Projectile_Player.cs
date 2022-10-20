using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Player : MonoBehaviour
{
    public float movement = .5f;
    public GameObject gun;
    private Vector2 aim; 
    public float range = 10; 
    Vector2 startPosition;

    // Start is called before the first frame update
    void Start()
    {
         aim = gun.transform.localPosition;
        Vector2 startPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate(movement/10, 0, 0);
       
        if (aim == new Vector2(1, 0))
        { 
            //shoot right 
            transform.Translate(movement / 10, 0, 0);
            
        }

        else if (aim == new Vector2(0, 1))
        {
            //shoot up
            transform.Translate(0, movement / 10, 0); 
        }
        else if (aim == new Vector2(-1, 0))
        {
            //shoot left
            transform.Translate(-movement / 10, 0, 0);
        }
        else if (aim == new Vector2(0, -1))
        {
            //shoot down
            transform.Translate(0, -movement / 10,  0);
        }
        else if (aim == new Vector2(1, 1))
        {
            //shoot top right
            transform.Translate(movement/10, movement / 10, 0);
        }
        else if (aim == new Vector2(-1, 1))
        {
            //shoot top left
            transform.Translate(-movement / 10, movement / 10, 0);
        }
        else if (aim == new Vector2(1, -1))
        {
            //shoot bottom right
            transform.Translate(movement / 10, -movement / 10, 0);
        }
        else if (aim == new Vector2(-1, -1))
        {
            //shoot bottom left
            transform.Translate(-movement / 10, -movement / 10, 0);
        }
        //despawn bullet after distance
//        if (Vector2.Distance(startPosition, transform.position) > range) 
  //      {
    //        Destroy(gameObject);
      //  }
    }
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("wanting to collided!");
        if (collision.gameObject != gun.transform.parent.gameObject)
        {
            Destroy(gameObject);
            Debug.Log("colliding!");
        }
    }

}


