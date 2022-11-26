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
    [SerializeField] GameObject freeze;
    public GameObject spawnOnDeath;

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
                Icecube ic = Instantiate(freeze).GetComponent<Icecube>();
                ic.eh = collision.gameObject.GetComponent<EnemyHealth>();
                collision.gameObject.GetComponent<EnemyHealth>().frozen += freezes;
            }

            if (!enemyPiercing) 
            {
                if (spawnOnDeath != null)
                {
                    Instantiate(spawnOnDeath, transform.position, Quaternion.identity);
                }

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
        else if(defects && collision.gameObject.tag == "Projectile")
        {
            Destroy(collision.gameObject);
        }
    }
}
