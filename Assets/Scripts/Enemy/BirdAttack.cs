using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdAttack : MonoBehaviour
{
    public GameObject birdeggPrefab;
    private IEnumerator coroutine;
    private bool CanShoot;

    // Start is called before the first frame update
    void Start()
    {
        CanShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<EnemyHealth>().frozen <= 0)
            Create2DRay();
    }

    private void Create2DRay()
    {
        LayerMask mask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 50, mask);

        if (hit.collider.gameObject.GetComponent<Health>() != null && CanShoot)
        {
            Instantiate(birdeggPrefab, transform.position, Quaternion.identity);
            CanShoot = false;
            StartCoroutine(AttackWait(1f));
            Debug.Log("Fired");
        }
    }

    private IEnumerator AttackWait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        CanShoot = true;   
    }
}
