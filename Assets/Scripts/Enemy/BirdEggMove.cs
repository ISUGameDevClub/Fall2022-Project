using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdEggMove : MonoBehaviour
{
    [SerializeField]
    [Range(0.001f,20f)]
    float
        speed;
    void FixedUpdate()
    {
       GetComponent<Rigidbody2D>().MovePosition((GetComponent<Rigidbody2D>().position-new Vector2(0,speed) * Time.fixedDeltaTime));
    }
}
