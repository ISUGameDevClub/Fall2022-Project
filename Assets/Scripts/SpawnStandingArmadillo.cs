using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStandingArmadillo : MonoBehaviour
{
    public GameObject standingarmadilloPrefab;
    [SerializeField] int health;
    private int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Projectile_Player>())
        {
            Destroy(collision.gameObject);
            currentHealth--;
            if (currentHealth <= 0)
            {
                Instantiate(standingarmadilloPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
