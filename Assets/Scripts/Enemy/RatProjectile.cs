using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatProjectile : MonoBehaviour
{
    private int direction;
    private Rigidbody2D rB;
    private DogMovement dM;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        dM = GetComponent<DogMovement>();
    }
    public void SetDirection(int dir)
    {
        direction = dir;
    }
    public void Launch(float launchForce)
    {
        rB.AddForce(new Vector2(direction,1)*launchForce,ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            dM.enabled = true;
        }
    }
}
