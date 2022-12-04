using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishShoot : MonoBehaviour
{
    // public GameObject fishprojectileleftPrefab;
    // public GameObject fishprojectilerightPrefab;
    [SerializeField] GameObject shootPrefab;
    public GameObject fishprojectilePrefab;
    public bool facingRight;
    public float activateDistance = 10;
    private Transform playerTransform;
    private bool isShooting;
    [SerializeField] float attackCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyHealth>().frozen <= 0 && playerTransform != null)
        {
            if (Vector2.Distance(this.transform.position, playerTransform.position) < activateDistance && !isShooting)
            {
                isShooting = true;
                StartCoroutine(AttackWait(attackCooldown));
            }
        }
    }

    private IEnumerator AttackWait(float waitTime)
    {
        while(waitTime > 0)
        {
            yield return new WaitForSeconds(waitTime);
            if (GetComponent<EnemyHealth>().frozen <= 0)
            {
                GameObject tempBul = Instantiate(fishprojectilePrefab, transform.position, Quaternion.identity);
                Instantiate(shootPrefab, transform.position, Quaternion.identity);
                tempBul.GetComponent<FishProjectileMove>().right = facingRight;
            }
        }
    }
}
