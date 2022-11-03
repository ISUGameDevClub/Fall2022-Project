using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class Racoon : MonoBehaviour
{
    [SerializeField] private float range = 10.0f;
    [SerializeField] private bool invulnerable = true;
    [SerializeField] private GameObject trashcan;
    public float speed = 2.1f, fireRate = 1.0f, fireDelay = 0.0f;

    public Animator anim;
    private BoxCollider2D collider;
    private SpriteRenderer renderer;

    public GameObject bullet; //The 'projectile' prefab
    public Transform weapon; //the weapon the bullet is firing from

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
            Fire();
        }

    }

    private void Fire()
    {
        if (Time.time > fireDelay)
        {
            fireDelay = Time.time + fireRate; //fireRate instantiates as making the enemy fire every 1 second.
            Vector2 myPos = new Vector2(weapon.position.x, weapon.position.y);
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity);
            Vector2 direction = (Vector2)player.transform.position - myPos; //get the direction of the player.
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed; //shoot projectile
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

