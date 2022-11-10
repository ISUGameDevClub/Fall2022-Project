using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchGunProjectile : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeTurnAround;

    [SerializeField]
    private float turnAroundAcceleration;

    private bool turnAround;

    public float movement = .5f;
    private float endMovement;
    public float despawnTime = .5f;
    public GameObject gun;
    private Rigidbody2D rb;
    private Attack atk;

    // Start is called before the first frame update
    void Start()
    {
        atk = GetComponent<Attack>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, despawnTime);

        endMovement = -movement;
        StartCoroutine(timeAfterShoot());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (turnAround && movement > endMovement)
        {
            movement -= turnAroundAcceleration * Time.deltaTime;
        }

        rb.MovePosition((Vector2)transform.position + movement * atk.moveDirection * Time.deltaTime);
    }

    private IEnumerator timeAfterShoot()
    {
        yield return new WaitForSeconds(timeBeforeTurnAround);
        turnAround = true;      
    }
}
