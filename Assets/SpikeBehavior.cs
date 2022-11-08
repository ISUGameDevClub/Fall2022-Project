using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().loseHealth();
        }else if (collision.gameObject.GetComponent<EnemyHealth>()!=null)
        {
            collision.gameObject.GetComponent<EnemyHealth>().TakeDamage();
        }
    }
}
