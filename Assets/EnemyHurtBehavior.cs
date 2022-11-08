using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtBehavior : MonoBehaviour
{
    [SerializeField] bool playerPiercing;
    [SerializeField] bool wallPiercing;
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.GetComponent<Health>() != null)
        {
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
                Destroy(gameObject);
            }
        }
    }
}
