using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] float maxCooldown;
    [SerializeField] SpriteRenderer hatSprite;
    [SerializeField] GameObject hurtPrefab;
    [SerializeField] GameObject powerDownPrefab;
    [SerializeField] GameObject powerUpPrefab;
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
    public void gainHealth(string powerup)
    {

        Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        Debug.Log("gained health");
        playerHealth = powerup;
        hatSprite.enabled = true;
    }


    //simple health loss method
    public void loseHealth()
    {
        if (damageCooldown <= 0)
        {
            Instantiate(hurtPrefab, transform.position, Quaternion.identity);
            if (playerHealth != "")
            {
                //rethink powerdown
                //Instantiate(powerDownPrefab, transform.position, Quaternion.identity);
                playerHealth = "";
                hatSprite.enabled = false;
            }
            else
            {
                FindObjectOfType<SceneTransition>().RestartScene();
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
        if (collision.gameObject.tag == "Kill")
        {
            die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag == "Kill")
        {
            die();
        }
    }


}
