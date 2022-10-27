using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for the enemy's 'ranged' attack.
//The player's health script already takes care of enemy melee.

//TESTING: Made and attached this script to "GenericEnemy" object for testing.

//Still need to make bullet object invisible then make it visible when it is instantiated and shot.
//Need to despawn objects a few seconds after they've been shot or when they collide with the player.
//Collider says "no camera" when "IS TRIGGER" is on because the player dies. Need to distinguish the boxcollider of a melee attack vs the range of a bullet. 

public class EnemyAttack : MonoBehaviour
{
    public float speed = 2.1f, fireRate = 1.0f, fireDelay = 0.0f;
    //public Rigidbody2D rb;
    public Transform weapon; //the weapon the bullet is firing from
    public GameObject bullet; //The 'projectile' prefab
    public Transform player;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        if(Time.time > fireDelay)
        {
            fireDelay = Time.time + fireRate; //fireRate instantiates as making the enemy fire every 1 second.
            Vector2 myPos = new Vector2(weapon.position.x, weapon.position.y);
            GameObject projectile = Instantiate(bullet, myPos, Quaternion.identity);
            Vector2 direction = (Vector2)player.position - myPos; //get the direction of the player.
            projectile.GetComponent<Rigidbody2D>().velocity = direction * speed; //shoot projectile
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Fire();
        }
    }

}
