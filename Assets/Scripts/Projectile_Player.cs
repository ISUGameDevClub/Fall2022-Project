using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Player : MonoBehaviour
{

    public float movement = .5f;
    public float despawnTime = .5f;
    public GameObject gun;
    private Vector2 aim; 
    Vector2 startPosition;
    private Rigidbody2D rb;
    private Attack atk;

    // Start is called before the first frame update
    void Start()
    {
        atk = GetComponent<Attack>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, despawnTime);
        aim = gun.transform.localPosition;
        Vector2 startPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + movement * atk.moveDirection * Time.deltaTime);
    }
}


