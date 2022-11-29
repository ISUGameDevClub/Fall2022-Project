using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBehavior : MonoBehaviour
{
    [SerializeField] bool playerPiercing;
    [SerializeField] bool wallPiercing;
    [SerializeField] float knockbackForce;
    [SerializeField] GameObject spawnOnDeath;
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
            collision.gameObject.GetComponent<Health>().loseHealth();
            if (collision.gameObject.GetComponent<Rigidbody2D>())
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction , ForceMode2D.Impulse);
            }
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
