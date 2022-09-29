using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int maxHealth = 2;
    [SerializeField] int maxCooldown = 60;
    public int PlayerHealth;
    int damageCooldown;
    int healCooldown;

    
    void Start()
    {
        PlayerHealth = maxHealth;
        damageCooldown = 0;
        healCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (damageCooldown > 0)
        {
            damageCooldown--;
        }

        if (healCooldown > 0)
        {
            healCooldown--;
        }


     if (PlayerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


    //simple Health Gain method
    public void gainHealth()
    {
        if (PlayerHealth < maxHealth)
        {
            PlayerHealth++;
            healCooldown = maxCooldown;
        }
    }


    //simple health loss method
    public void loseHealth()
    {
        PlayerHealth--;
        damageCooldown = maxCooldown;
    }

    //lose all health method
    public void die()
    {
        PlayerHealth = 0;
    }

    //check for collision
    private void OnCollisionStay2D(Collision2D collision)
    {

        //If collision is enemy type, take one damage
        if (collision.gameObject.tag == "Enemy")
        {
            if (damageCooldown == 0)
            {
                loseHealth();
            }
        }

        //If collision is heal type, heal one health
        if (collision.gameObject.tag == "Health")
        {
             if (healCooldown == 0)
             {
                gainHealth();
             }
         }

    }



}
