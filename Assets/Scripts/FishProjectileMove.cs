using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishProjectileMove : MonoBehaviour
{
    public bool right;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (right)
        {
            transform.Translate(new Vector2(1, 0) * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(new Vector2(-1, 0) * Time.deltaTime * speed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }


}
