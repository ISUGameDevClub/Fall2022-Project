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

    public GameObject gun;
    public float movement = .5f;
    private float bulletSpeed;
    private float endSpeed;
    private Rigidbody2D rb;
    private Attack atk;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        atk = GetComponent<Attack>();
        turnAround = false;
        bulletSpeed = movement;
        endSpeed = -bulletSpeed;

        StartCoroutine(timeAfterShoot());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (turnAround && bulletSpeed > endSpeed)
        {
            bulletSpeed -= turnAroundAcceleration * Time.deltaTime;
        }

        rb.MovePosition(bulletSpeed * atk.moveDirection * Time.deltaTime);
    }


    private IEnumerator timeAfterShoot()
    {
        yield return new WaitForSeconds(timeBeforeTurnAround);
        turnAround = true;      
    }
}
