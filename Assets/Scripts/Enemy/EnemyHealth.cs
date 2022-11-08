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
    public void TakeDamage(int dmg)
    {
        currentHealth-=dmg;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
