using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] int maxHealth = 2;
    [SerializeField] int maxCooldown = 60;
    public int playerHealth = 2;
    public Text playerHealthText;
    int damageCooldown;
    int healCooldown;
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
            playerHealth++;
            healCooldown = maxCooldown;
        }
    }


    //simple health loss method
    public void loseHealth()
    {
        playerHealth--;
        damageCooldown = maxCooldown;
    }

    //lose all health method
    public void die()
    {
        playerHealth = 0;
    }

    //check for collision
    private void OnTriggerEnter2D(Collider2D collision)
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
