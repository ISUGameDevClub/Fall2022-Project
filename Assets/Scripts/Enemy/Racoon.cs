using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racoon : MonoBehaviour
{
    [SerializeField] private float rate = 0.005f;
    [SerializeField] private float range = 10.0f;
    [SerializeField] private bool invulnerable = true;
    [SerializeField] private GameObject trashcan;

    private BoxCollider2D collider;
    private SpriteRenderer renderer;

    private GameObject player;
    public float movementProgress = 0.0f;

    void Start(){
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");
    }

    void Update(){
        // Range check
        float distance = (player.transform.position - transform.position).sqrMagnitude;
        invulnerable = !(distance < range * range);
        movementProgress += Mathf.Clamp((invulnerable ? 1 : 0) - movementProgress, -rate, rate);

        // Vulerable behavior
        if(!invulnerable){
            Vector2 direction = (player.transform.position - transform.position).normalized;
        }

        renderer.enabled = !invulnerable;
        trashcan.GetComponent<SpriteRenderer>().enabled = invulnerable;
    }
}
