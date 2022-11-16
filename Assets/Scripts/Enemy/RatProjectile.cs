using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatProjectile : MonoBehaviour
{
    private int direction;
    private Rigidbody2D rB;
    // Start is called before the first frame update
    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
    }
    public void SetDirection(int dir)
    {
        direction = dir;
    }
    public void Launch()
    {
        rB.AddForce(new Vector2(direction,1),ForceMode2D.Impulse);
    }
}
