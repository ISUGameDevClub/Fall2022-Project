using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Player : MonoBehaviour
{

    public float movement = .5f;
    public float despawnTime = .5f;

    public bool bounces;
    public bool homing;
    public bool delayedHoming;
    public bool startOutwards;
    public bool startInwards;

    public bool drops;
    public float verticalLaunch;
    public float gradualVerticalDrop;

    public bool sticky;

    private Rigidbody2D rb;
    private Attack atk;
    private GameObject closestEnemy;
    private Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        atk = GetComponent<Attack>();
        rb = GetComponent<Rigidbody2D>();

        if (startOutwards)
        {
<<<<<<< HEAD
            startPos = transform.localPosition;
            transform.localPosition = startPos + ((GetComponent<SpriteRenderer>().size.x / 2) * atk.moveDirection);
            transform.right = (Vector2)transform.localPosition - startPos;
            transform.localPosition = (Vector2)transform.position + new Vector2(0, .25f);
            transform.parent = FindObjectOfType<PlayerMovement>().gameObject.transform;
=======
            startPos = transform.position;
            transform.position = startPos + ((GetComponent<SpriteRenderer>().size.x / 2) * atk.moveDirection);
            transform.right = (Vector2)transform.position - startPos;
>>>>>>> parent of 357c294 (fixed Hats)
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

        if(delayedHoming)
        {
            StartCoroutine(DelayedHomingEnum());
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

        if (movement != 0)
        {
            Vector2 vertLaunch = new Vector2(0, verticalLaunch);
            if (drops)
                verticalLaunch -= gradualVerticalDrop * Time.fixedDeltaTime;

            rb.MovePosition((Vector2)transform.position + vertLaunch + movement * atk.moveDirection.normalized * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(sticky && collision.gameObject.tag == "Ground")
        {
            movement = 0;
            drops = false;
            verticalLaunch = 0;
            StartCoroutine(ExplodeAfterTime());
        }
    }

    private IEnumerator ExplodeAfterTime()
    {
        yield return new WaitForSeconds(1);
        Instantiate(GetComponent<PlayerHurtBox>().spawnOnDeath, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }    
    
    private IEnumerator DelayedHomingEnum()
    {
        yield return new WaitForSeconds(.75f);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closest = Mathf.Infinity;
        foreach (GameObject enemy in enemies)
        {
            if (Vector2.Distance(transform.position, enemy.transform.position) < closest)
            {
                closest = Vector2.Distance(transform.position, enemy.transform.position);
                closestEnemy = enemy;
            }
        }

        homing = true;
        drops = false;
        verticalLaunch = 0;
    }
}


