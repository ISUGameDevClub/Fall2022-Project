using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] GameObject hurtPrefab;
    [SerializeField] GameObject diePrefab;
    [SerializeField] Animator enemyAnimator;
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

        currentHealth-=dmg;
        if (currentHealth <= 0)
        {
            Instantiate(diePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else 
        { 
            Instantiate(hurtPrefab, transform.position, Quaternion.identity);
            enemyAnimator.SetTrigger("Hurt");
        }
    }
}
