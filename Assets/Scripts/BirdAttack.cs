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
        coroutine = AttackWait(2.0f);
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        Create2DRay();
    }

    private void Create2DRay()
    {
        LayerMask mask = LayerMask.GetMask("Player");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 5, mask);

        if (hit.collider != null)
        {
            Instantiate(birdeggPrefab, transform.position, Quaternion.identity);
        }
    }

    private IEnumerator AttackWait(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
        }
    }
}
