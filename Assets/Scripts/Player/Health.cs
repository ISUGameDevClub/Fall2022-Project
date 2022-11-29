using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] SpriteRenderer hatSprite;
    [SerializeField] GameObject hurtPrefab;
    [SerializeField] GameObject powerDownPrefab;
    [SerializeField] GameObject powerUpPrefab;
    [SerializeField] GameObject hatAnimPrefab;
    [SerializeField] Animator topSprite;
    [SerializeField] Animator bottomSprite;
    [SerializeField] GameObject powerupText;
    [SerializeField] float powerupWaitTime = 1.5f;
    public string playerHealth;
    //public Text playerHealthText;
    private GameObject player;
    bool invincible;
    [SerializeField] float invincibleFrames;



    void Start()
    {
        playerHealth = "";
        //playerHealthText.text = playerHealth;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    { 
        if (playerHealth == null)
        {
            Destroy(gameObject);
        }
    }

    //simple Health Gain method
    public void gainHealth(string powerup)
    {
        Instantiate(powerUpPrefab, transform.position, Quaternion.identity);
        playerHealth = powerup;
        hatSprite.enabled = true;
        PowerupPause();
        topSprite.SetTrigger("Power");
        bottomSprite.SetTrigger("Power");
    }
    public void PowerupPause()
    {
        Time.timeScale = 0;
        powerupText.GetComponent<TMP_Text>().text = playerHealth.ToString().ToUpper();
        powerupText.SetActive(true);
        StartCoroutine(PowerupWait());
    }
    private IEnumerator PowerupWait()
    {
        yield return new WaitForSecondsRealtime(powerupWaitTime);
        Time.timeScale = 1;
        powerupText.SetActive(false);
    }
    //simple health loss method
    public void loseHealth()
    {
        topSprite.SetBool("isHurt", true);
        bottomSprite.SetBool("isHurt", true);
        if (!invincible)
        {
            Instantiate(hurtPrefab, transform.position, Quaternion.identity);
            if (playerHealth != "")
            {
                Sprite hatSpriteCopy = hatSprite.sprite;
                GameObject hatSpriteAnim = Instantiate(hatAnimPrefab, transform.position, Quaternion.identity);
                hatSpriteAnim.GetComponent<SpriteRenderer>().sprite = hatSpriteCopy;
                Destroy(hatSpriteAnim, 5f);
                //rethink powerdown
                //Instantiate(powerDownPrefab, transform.position, Quaternion.identity);
                playerHealth = "";
                hatSprite.enabled = false;
            }
            else
            {
                playerHealth = null;
                FindObjectOfType<SceneTransition>().RestartScene();
            }
            invincible = true;
            StartCoroutine(InvincibleFrames());
        }

    }
    private IEnumerator InvincibleFrames()
    {
        yield return new WaitForSeconds(invincibleFrames);
        invincible = false;
        topSprite.SetBool("isHurt", false);
        bottomSprite.SetBool("isHurt", false);
    }
    public void ClearInvincible()
    {
        topSprite.SetBool("isHurt", false);
        bottomSprite.SetBool("isHurt", false);
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
