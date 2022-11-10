using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    [SerializeField] bool enemyPiercing;
    [SerializeField] bool wallPiercing;
    [SerializeField] int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            if (!enemyPiercing) 
            {
                Destroy(gameObject);
            }
        }
        else if (collision.gameObject.tag == "Ground")
        {
            if (!wallPiercing)
            {
                Destroy(gameObject);
            }
        }
    }
}
