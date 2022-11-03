using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTest : MonoBehaviour
{
    /*
    [SerializeField] float range = 10.0f;
    [SerializeField] float timeVuln = 3;
    [SerializeField] float timeInv = 2;
    public float enemySpeed = 4;
    private float direction = 1.0f;

    [SerializeField] bool invulnerable = true;
    private bool firstEncounter = false;

    private BoxCollider2D collider;
    private SpriteRenderer renderer;
    private Rigidbody2D rb;
    private GameObject player;
    
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        rb.MovePosition(rb.position + new Vector2(-1, 0) * Time.fixedDeltaTime * direction * enemySpeed + new Vector2(0, fallSpeed) * Time.fixedDeltaTime);
        Create2DRay();
    }
    private void Create2DRay()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * direction, wallDetectRange, mask);
    }


    void Update()
    {
        // Range check
        float distance = (player.transform.position - transform.position).sqrMagnitude;
        if (distance < range * range && invulnerable)
        {
            invulnerable = false;
            firstEncounter = true;
        }

        if(firstEncounter)
        {
            //Allow Attack

            StartCoroutine(AttackWait(timeVuln));
        }
        if (timeVuln > interval)
        {
            invulnerable = true;
            timeVuln = 0;
        }

        // Invulerability behavior
        if (!invulnerable)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;

            // Speed check
            if(rb.velocity.sqrMagnitude < maxVelocity * maxVelocity){
                rb.AddForce(new Vector2(1, 0) * Time.deltaTime * direction * enemySpeed);
            }
        }
       

        rb.isKinematic = invulnerable;
        rb.simulated = !invulnerable;
        collider.enabled = !invulnerable;
        renderer.enabled = !invulnerable;
    }


    private IEnumerator AttackWait(float wait)
    {
        yield return new WaitForSeconds(wait);
        invulnerable = true;
    }
    */
}
