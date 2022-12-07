using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private GameObject player;
    private GameObject player2;
    private bool playerOnPlatform;

    [SerializeField]
    private bool platformBreak;

    [SerializeField]
    private float platfromBreakTime;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        player2 = GameObject.Find("Player 2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
    }

    private IEnumerator EnableCollider2()
    {
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(player2.GetComponent<Collider2D>(), GetComponent<Collider2D>(), false);
    }

    private IEnumerator PlatformBreakTimer()
    {
        yield return new WaitForSeconds(platfromBreakTime);
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        StartCoroutine(EnableCollider());
        
    }

    private IEnumerator PlatformBreakTimer2()
    {
        yield return new WaitForSeconds(platfromBreakTime);
        Physics2D.IgnoreCollision(player2.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
        StartCoroutine(EnableCollider());

    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            if (Input.GetAxisRaw("Vertical") < 0)
            {
                Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
                StartCoroutine(EnableCollider());
            }

            if (Input.GetAxisRaw("Vertical2") < 0)
            {
                Physics2D.IgnoreCollision(player2.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true);
                StartCoroutine(EnableCollider2());
            }

            if (platformBreak && player.transform.position.y > transform.position.y)
            {
                StartCoroutine(PlatformBreakTimer());
            }

            if (platformBreak && player2.transform.position.y > transform.position.y)
            {
                StartCoroutine(PlatformBreakTimer2());
            }
        }
    }


}
