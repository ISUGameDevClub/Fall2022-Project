using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishProjectileMove : MonoBehaviour
{
    public bool right;
    public float speed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (right)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = true;
            rb.MovePosition((Vector2)transform.position + speed * Vector2.right * Time.fixedDeltaTime);
        }
        else
        {
            rb.MovePosition((Vector2)transform.position + speed * Vector2.left * Time.fixedDeltaTime);
        }
    }


}
