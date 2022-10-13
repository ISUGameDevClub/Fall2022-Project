using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            /*If a player is wearing a hat, make them lose the hat.
             * If a player !wearing a hat, they die
             * collision.gameObject.GetComponent<Health>().
             */

            //looks like Player's health script actually takes care of the enemy melee
            
        }
    }

}
