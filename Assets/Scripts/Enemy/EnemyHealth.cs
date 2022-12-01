using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject hurtPrefab;
    [SerializeField] GameObject diePrefab;
    [SerializeField] GameObject transformPrefab;
    [SerializeField] Animator enemyAnimator;
    [HideInInspector]
    public bool invincible;
    [HideInInspector]
    public float frozen;

    private int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    private void Update()
    {
        if(frozen > 0)
        {
            frozen -= Time.deltaTime;
        }
        else
        {
            frozen = 0;
        }
    }
    public void TakeDamage(int dmg)
    {
        if(!invincible)
        {
            currentHealth -= dmg;
            if (currentHealth <= 0 && diePrefab != null)
            {
                if (transformPrefab != null)
                {
                    Instantiate(transformPrefab, transform.position, Quaternion.identity);
                }
                else
                {
                    Instantiate(diePrefab, transform.position, Quaternion.identity);
                }
                Destroy(gameObject);
            }
            else if(hurtPrefab != null)
            {
                Instantiate(hurtPrefab, transform.position, Quaternion.identity);
                enemyAnimator.SetTrigger("Hurt");
            }
        }
    }
}
