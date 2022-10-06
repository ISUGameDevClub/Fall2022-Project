using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int maxHealth;
    [SerializeField] int maxCooldown;
    public int playerHealth = 2;
    public Text playerHealthText;
    float damageCooldown;
    float healCooldown;
    private GameObject player;

    
    void Start()
    {
        playerHealth = maxHealth;
        damageCooldown = 0;
        healCooldown = 0;
        playerHealthText.text = playerHealth.ToString();
        player = GameObject.Find("Player");
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


     if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }

        playerHealthText.text = playerHealth.ToString();

    }

    //simple Health Gain method
    public void gainHealth()
    {
        if (playerHealth < maxHealth)
        {
            if (healCooldown <= 0)
            {
                playerHealth++;
                healCooldown = maxCooldown * Time.frameCount / Time.time;
            }
            
        }
    }


    //simple health loss method
    public void loseHealth()
    {
        if (damageCooldown <= 0)
        {
            playerHealth--;
            damageCooldown = maxCooldown * Time.frameCount /Time.time;
        }
        
    }

    //lose all health method
    public void die()
    {
        playerHealth = 0;
    }

    //check for collision
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            loseHealth();
        }

        if (collision.gameObject.tag == "Health")
        {
            gainHealth();
        }

    }

}
