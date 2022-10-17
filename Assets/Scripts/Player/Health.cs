using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] int maxCooldown;
    public string playerHealth;
    //public Text playerHealthText;
    float damageCooldown;
    float healCooldown;
    private GameObject player;


    void Start()
    {
        playerHealth = "";
        damageCooldown = 0;
        healCooldown = 0;
        //playerHealthText.text = playerHealth;
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


     if (playerHealth == null)
        {
            Destroy(gameObject);
        }


    }

    //simple Health Gain method
    public void gainHealth()
    {
        if (playerHealth == "")
        {
            if (healCooldown <= 0)
            {
                playerHealth = "Walter White";
                //this will be more fleshed out later. Walter White is a test value
                healCooldown = maxCooldown * Time.frameCount / Time.time;
            }

        }
    }


    //simple health loss method
    public void loseHealth()
    {
        if (damageCooldown <= 0)
        {
            if(playerHealth != "")
            {
                playerHealth = "";
            }
            else
            {
                playerHealth = null;
            }
            damageCooldown = maxCooldown * Time.frameCount /Time.time;
        }

    }

    //lose all health method
    public void die()
    {
        playerHealth = null;
    }

    //check for collision
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            loseHealth();
        }

        if (collision.gameObject.tag == "Heal")
        {
            gainHealth();
        }

        if (collision.gameObject.tag == "Kill")
        {
            die();
        }

    }

}
