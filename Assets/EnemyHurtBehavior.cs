using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBehavior : MonoBehaviour
{
    [SerializeField] bool playerPiercing;
    [SerializeField] bool wallPiercing;
    [SerializeField] float knockbackForce;
    [SerializeField] GameObject spawnOnDeath;
    [SerializeField] Animator enemyAnim;
    [SerializeField] AudioSource attackSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector2 direction = collision.transform.position - transform.position;
        if (direction.x > 0)
        {
            direction = new Vector2(Mathf.Clamp(direction.x,.45F,1), Mathf.Clamp(direction.y, .45f, 1)) * knockbackForce * 10;
        }
        else
        {
            direction = new Vector2(Mathf.Clamp(direction.x, -.45F, -1), Mathf.Clamp(direction.y, .45f, 1)) * knockbackForce * 10;
        }
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            if (enemyAnim != null)
            {
                enemyAnim.SetTrigger("Attack");
            }
            if (attackSound != null)
            {
                attackSound.Play();
            }
            collision.gameObject.GetComponent<Health>().loseHealth();
            if (!playerPiercing)
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Ground")
        {
            if (!wallPiercing)
            {
                if(spawnOnDeath != null)
                {
                    Instantiate(spawnOnDeath, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
        }
    }
}
