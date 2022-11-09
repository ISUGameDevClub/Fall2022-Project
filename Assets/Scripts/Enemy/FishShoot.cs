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
    [SerializeField] float attackCooldown = 1f;
    [SerializeField] float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AttackWait(attackCooldown));
    }

    // Update is called once per frame
    void Update()
    {
        //Create2DRayLeft();
        //Create2DRayRight();
    }

    /*private void Create2DRayLeft()
    {
        LayerMask mask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, 5, mask);

        if (hit.collider.gameObject.GetComponent<Health>() != null && CanShoot)
        {
            GameObject fishProj = Instantiate(fishprojectilePrefab, transform.position, Quaternion.identity);
            fishProj.GetComponent<FishProjectileMove>().left = true;
            CanShoot = false;
            StartCoroutine(AttackWait(1f));
        }
    }

    private void Create2DRayRight()
    {
        LayerMask mask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 5, mask);

        if (hit.collider.gameObject.GetComponent<Health>() != null && CanShoot)
        {
            Debug.Log("Right");
            GameObject fishProj = Instantiate(fishprojectilePrefab, transform.position, Quaternion.identity);
            fishProj.GetComponent<FishProjectileMove>().left = false;
            CanShoot = false;
            StartCoroutine(AttackWait(1f));
        }
    }
    */
    private IEnumerator AttackWait(float waitTime)
    {
        while(waitTime > 0)
        {
            GameObject tempBul = Instantiate(fishprojectilePrefab, transform.position, Quaternion.identity);
            Instantiate(shootPrefab, transform.position, Quaternion.identity);
            tempBul.GetComponent<FishProjectileMove>().right = facingRight;
            tempBul.GetComponent<FishProjectileMove>().speed = speed;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
