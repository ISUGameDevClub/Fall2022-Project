using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private float interval = 3.0f;
    [SerializeField] private float range = 10.0f;
    [SerializeField] private float maxVelocity = 600;
    [SerializeField] private float enemySpeed = 60;
    [SerializeField] private bool invulnerable = true;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private SpriteRenderer renderer;

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
        if(!invulnerable){
            Vector2 direction = (player.transform.position - transform.position).normalized;

            // Speed check
            if(rb.velocity.sqrMagnitude < maxVelocity * maxVelocity){
                rb.AddForce(new Vector2(1, 0) * Time.deltaTime * direction * enemySpeed);
            }

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
