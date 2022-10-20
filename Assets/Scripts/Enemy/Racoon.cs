using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class Racoon : MonoBehaviour
{
    public float frequency = 2;
    [SerializeField] private float rate = 0.005f;
    [SerializeField] private float range = 10.0f;
    [SerializeField] private bool invulnerable = true;
    [SerializeField] private GameObject trashcan;
    public int time;
    public int invTime;
    public Animator anim;
    private BoxCollider2D collider;
    private SpriteRenderer renderer;

    private GameObject player;
    public float movementProgress = 0.0f;

    void Start()
    {
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        renderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        // Range check
        float distance = (player.transform.position - transform.position).sqrMagnitude;
        invulnerable = !(distance < range * range);
        movementProgress += Mathf.Clamp((invulnerable ? 1 : 0) - movementProgress, -rate, rate);

        // Vulerable behavior
        if (!invulnerable)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
        }

        renderer.enabled = !invulnerable;
        trashcan.GetComponent<SpriteRenderer>().enabled = invulnerable;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot();
        }
    }

    void shoot()
    {
        StartCoroutine("RacoonShootWait");
    }

    void triggerShootAnim()
    {
        anim.SetTrigger("Shoot");

    }
    IEnumerator RacoonUpTime()
    {
        yield return new WaitForSeconds(invTime);
        triggerShootAnim();
    }
    IEnumerator RacoonShootWait()
    {
        yield return new WaitForSeconds(time);
        StartCoroutine("RacoonUpTime");
        triggerShootAnim();
    }

}

