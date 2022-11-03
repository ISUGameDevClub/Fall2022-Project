using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float interval = 3.0f;
    [SerializeField] private float range = 10.0f;
    [SerializeField] private float maxVelocity = 600;
    [SerializeField] private bool invulnerable = true;
    private BoxCollider2D collider;
    private SpriteRenderer renderer;

    private float direction = 1.0f;
    private Rigidbody2D rb;
    [SerializeField] float fallSpeed;
    public float wallDetectRange = 5;
    public float enemySpeed = 4;

    private GameObject player;
    private float timeVulernable = 0;
    private float timeInvulerable = 0;
    private bool firstEncounter = false;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        rb.velocity = Vector2.zero;
        rb.MovePosition(rb.position + new Vector2(-1, 0) * Time.fixedDeltaTime * direction * enemySpeed + new Vector2(0, fallSpeed)*Time.fixedDeltaTime);
        Create2DRay();
    }
    private void Create2DRay()
    {
        LayerMask mask = LayerMask.GetMask("Ground");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left * direction, wallDetectRange, mask);
    }


    void Update(){
        // Range check
        float distance = (player.transform.position - transform.position).sqrMagnitude;
        if((distance < range * range && invulnerable) || (firstEncounter && timeInvulerable > interval)){
            invulnerable = false;
            firstEncounter = true;
        }

        if(timeVulernable > interval){
            invulnerable = true;
            timeVulernable = 0;
        }

        // Invulerability behavior
        if(!invulnerable)
        {
            /*
            Vector2 direction = (player.transform.position - transform.position).normalized;

            // Speed check
            if(rb.velocity.sqrMagnitude < maxVelocity * maxVelocity){
                rb.AddForce(new Vector2(1, 0) * Time.deltaTime * direction * enemySpeed);
            }
            */


            timeVulernable += Time.deltaTime;
            timeInvulerable = 0;
        } else {
            timeInvulerable += Time.deltaTime;
        }

        rb.isKinematic = invulnerable;
        rb.simulated = !invulnerable;
        collider.enabled = !invulnerable;
        renderer.enabled = !invulnerable;
    }
}
