using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatShoot : MonoBehaviour
{
    // public GameObject fishprojectileleftPrefab;
    // public GameObject fishprojectilerightPrefab;
    public GameObject fishprojectilePrefab;
    public bool facingRight;
    public float activateDistance = 10;
    private Transform playerTransform;
    private bool isShooting;
    [SerializeField] float attackCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sR = GetComponentInChildren<SpriteRenderer>();
        if (facingRight)
        {
            sR.flipX = true;
        }
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        isShooting = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerTransform != null && Vector2.Distance(this.transform.position, playerTransform.position) < activateDistance && !isShooting)
        {
            isShooting = true;
            StartCoroutine(AttackWait(attackCooldown));
        }
    }

    private IEnumerator AttackWait(float waitTime)
    {
        while (waitTime > 0)
        {
            GameObject tempBul = Instantiate(fishprojectilePrefab, transform.position, Quaternion.identity);
            if (facingRight)
            {
                tempBul.GetComponent<Attack>().moveDirection = new Vector2(1, 0);
            }else
            {
                tempBul.GetComponent<Attack>().moveDirection = new Vector2(-1, 0);
            }
            yield return new WaitForSeconds(waitTime);
        }
    }
}
