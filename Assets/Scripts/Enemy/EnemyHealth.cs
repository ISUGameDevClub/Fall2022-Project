using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile_Player>())
        {
            Destroy(collision.gameObject);
            currentHealth--;
            if (currentHealth <= 0)
            {

                Destroy(gameObject);
            }
        }
    }
}
