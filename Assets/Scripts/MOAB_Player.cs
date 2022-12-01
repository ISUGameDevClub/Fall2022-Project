using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MOAB_Player : MonoBehaviour
{

    public float throwForce = .5f;
    //public float despawnTime = .5f;
    public GameObject gun;
    private Vector2 aim; 
    Vector2 startPosition;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {

        //Destroy(gameObject, despawnTime);
        aim = gun.transform.localPosition;
        Vector2 startPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();



        if (aim == new Vector2(0.78f, 0.413f) ||
            aim == new Vector2(1, 1))
        {
            //throw right 
            rb.AddForce(new Vector2(throwForce, throwForce));
        }
        else if (aim == new Vector2(1, -1))
        {
            //underhand right
            rb.AddForce(new Vector2(throwForce, throwForce / 2));
        }
        else if (aim == new Vector2(-0.78f, 0.413f) ||
            aim == new Vector2(-1, 1))
        {
            //throw left
            rb.AddForce(new Vector2(-throwForce, throwForce));
        }
        else if (aim == new Vector2(-1, -1))
        {
            //underhand left
            rb.AddForce(new Vector2(-throwForce, throwForce / 2));
        }
        else if (aim == new Vector2(0, -1))
        {
            //drop at feet
            rb.AddForce(new Vector2(0, 0));
        }
        else if (aim == new Vector2(0, 1))
        {
            //throw straight up
            rb.AddForce(new Vector2(0, throwForce));
        }

    }
}


