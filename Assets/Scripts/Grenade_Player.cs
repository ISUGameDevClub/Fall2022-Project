using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Player : MonoBehaviour
{

    public float throwForce = .5f;
    public float despawnTime = .5f;

    Rigidbody2D rb;
    private Attack atk;

    // Start is called before the first frame update
    void Start()
    {
        atk = GetComponent<Attack>();
        Destroy(gameObject, despawnTime);
        Vector2 startPosition = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();

        rb.AddForce(atk.moveDirection * throwForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }

}


