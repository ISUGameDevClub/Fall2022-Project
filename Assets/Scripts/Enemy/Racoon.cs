using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class Racoon : MonoBehaviour
{
    [SerializeField] private float range = 10.0f;
    [SerializeField] private bool invulnerable = true;

    private bool canShootNow;

    public float shotDelayValue = 1f;
    public float bulletSpeed = 2.1f;

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

        canShootNow = true;
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
        if(!invulnerable)
        {
           //Actual shooting
            Fire();
        }

    }

    private void Fire()
    {
        if (canShootNow)
        {
            canShootNow = false;
            Vector2 myPos = new Vector2(weapon.position.x, weapon.position.y);
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity);

            float direction = 1;//get the direction of the player.
            if(player.transform.position.x < myPos.x)
            {
                direction = -1;
            }
            else
            {
                direction = 1;
            }
            projectile.GetComponent<Rigidbody2D>().velocity = Vector2.right * direction * bulletSpeed; //shoot projectile

            StartCoroutine(shotDelay());
        }
    }

    private IEnumerator shotDelay()
    {
        yield return new WaitForSeconds(shotDelayValue);
        canShootNow = true;
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

