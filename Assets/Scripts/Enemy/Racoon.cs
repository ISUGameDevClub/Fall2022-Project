using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class Racoon : MonoBehaviour
{
    [SerializeField] private float fireRate = 0.05f;
    [SerializeField] private float range = 10.0f;
    [SerializeField] private bool invulnerable = true;
    [SerializeField] private GameObject trashcan;
    public int vunTime =30;
    public int invTime = 10;
    public Animator anim;
    private BoxCollider2D collider;
    private SpriteRenderer renderer;

    private GameObject player;

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
        float distance = Vector2.Distance(transform.position,player.transform.position);
        if(distance < range)
        {
            shoot();
        }
        // Vulerable behavior
        renderer.enabled = !invulnerable;
        trashcan.GetComponent<SpriteRenderer>().enabled = invulnerable;
        if(!invulnerable)
        {
            //Actual shooting

        }

    }

    void shoot()
    {
        StartCoroutine("RacoonUpTime");
    }
    IEnumerator RacoonUpTime()
    {
        triggerShootAnim();
        yield return new WaitForSeconds(40);
        anim.SetTrigger("Idle");
    }
    void triggerShootAnim()
    {
        anim.SetTrigger("Shoot");
    }
    
    /* Unused as of now
    IEnumerator RacoonShootWait()
    {
        yield return new WaitForSeconds(invTime);
        StartCoroutine("RacoonUpTime");
        triggerShootAnim();
    }
    */
}

