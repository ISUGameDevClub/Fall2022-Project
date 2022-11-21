using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Player : MonoBehaviour
{

    public float movement = .5f;
    public float despawnTime = .5f;

    public bool bounces;

    private Rigidbody2D rb;
    private Attack atk;

    // Start is called before the first frame update
    void Start()
    {
        atk = GetComponent<Attack>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, despawnTime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bounces)
        {
            RaycastHit2D[] hits = new RaycastHit2D[4];
            LayerMask mask = LayerMask.GetMask("Ground");
            hits[0] = Physics2D.Raycast(transform.position, Vector2.up, .75f, mask);
            hits[1] = Physics2D.Raycast(transform.position, Vector2.right, .75f, mask);
            hits[2] = Physics2D.Raycast(transform.position, Vector2.down, .75f, mask);
            hits[3] = Physics2D.Raycast(transform.position, Vector2.left, .75f, mask);


            if (hits[0].collider != null)
            {
                atk.moveDirection = new Vector2(atk.moveDirection.x, -Mathf.Abs(atk.moveDirection.y));
            }
            else if (hits[1].collider != null)
            {
                atk.moveDirection = new Vector2(-Mathf.Abs(atk.moveDirection.x), atk.moveDirection.y);
            }
            else if (hits[2].collider != null)
            {
                atk.moveDirection = new Vector2(atk.moveDirection.x, Mathf.Abs(atk.moveDirection.y));
            }
            else if (hits[3].collider != null)
            {
                atk.moveDirection = new Vector2(Mathf.Abs(atk.moveDirection.x), atk.moveDirection.y);
            }
        }

        rb.MovePosition((Vector2)transform.position + movement * atk.moveDirection * Time.deltaTime);
    }
}


