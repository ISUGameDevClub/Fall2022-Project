using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Player : MonoBehaviour
{

    public float movement = .5f;
    public float despawnTime = .5f;

    public bool bounces;
    public bool homing;
    public bool startOutwards;
    public bool startInwards;

    private Rigidbody2D rb;
    private Attack atk;
    private GameObject closestEnemy;

    // Start is called before the first frame update
    void Start()
    {
        atk = GetComponent<Attack>();
        rb = GetComponent<Rigidbody2D>();

        if (startOutwards)
        {
            transform.position = (Vector2)FindObjectOfType<PlayerMovement>().gameObject.transform.position + ((GetComponent<SpriteRenderer>().size.x / 2) * atk.moveDirection);
            transform.right = (Vector2)transform.position - (Vector2)FindObjectOfType<PlayerMovement>().gameObject.transform.position;
        }
        else if(startInwards)
        {
            transform.position = (Vector2)FindObjectOfType<PlayerMovement>().gameObject.transform.position;
        }

        if(homing)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            float closest = Mathf.Infinity;
            foreach(GameObject enemy in enemies)
            {
                if(Vector2.Distance(transform.position, enemy.transform.position) < closest){
                    closest = Vector2.Distance(transform.position, enemy.transform.position);
                    closestEnemy = enemy;
                }
            }
        }

        Destroy(gameObject, despawnTime);
    }

    private void Update()
    {
        if (homing)
        {
            atk.moveDirection = closestEnemy.transform.position - transform.position;
        }
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

        rb.MovePosition((Vector2)transform.position + movement * atk.moveDirection.normalized * Time.deltaTime);
    }
}


