using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishShoot : MonoBehaviour
{
    public GameObject fishprojectilePrefab;
    public bool facingRight;
    public float activateDistance;
    private Transform playerTransform;
    private bool isShooting;
    [SerializeField] float attackCooldown = 1f;
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(this.transform.position, playerTransform.position) < activateDistance && !isShooting)
        {
            isShooting = true;
            StartCoroutine(AttackWait(attackCooldown));
        }
    }

    private IEnumerator AttackWait(float waitTime)
    {
        while(waitTime > 0)
        {
            GameObject tempBul = Instantiate(fishprojectilePrefab, transform.position, Quaternion.identity);
            tempBul.GetComponent<FishProjectileMove>().right = facingRight;
            tempBul.GetComponent<FishProjectileMove>().speed = speed;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
