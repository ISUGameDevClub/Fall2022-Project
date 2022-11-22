using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtBox : MonoBehaviour
{
    [SerializeField] bool enemyPiercing;
    [SerializeField] bool wallPiercing;
    [SerializeField] int damage;
    [SerializeField] bool defects;
    [SerializeField] float freezes;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHealth>() != null)
        {
            if (damage > 0)
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            if(freezes > 0)
            {
                collision.gameObject.GetComponent<EnemyHealth>().frozen += freezes;
            }

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
        else if(defects && collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        }
    }
}
