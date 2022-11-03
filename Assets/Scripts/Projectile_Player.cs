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

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, despawnTime);
        aim = gun.transform.localPosition;
        Vector2 startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (aim == new Vector2(0.78f, 0.413f))
        {
            //shoot right 
            transform.Translate(movement / 10, 0, 0);

        }
        else if (aim == new Vector2(0, 1))
        {
            //shoot up
            transform.Translate(0, movement / 10, 0);
        }
        else if (aim == new Vector2(-0.78f, 0.413f))
        {
            //shoot left
            transform.Translate(-movement / 10, 0, 0);
        }
        else if (aim == new Vector2(0, -1))
        {
            //shoot down
            transform.Translate(0, -movement / 10, 0);
        }
        else if (aim == new Vector2(1, 1))
        {
            //shoot top right
            transform.Translate(movement / 10, movement / 10, 0);
        }
        else if (aim == new Vector2(-1, 1))
        {
            //shoot top left
            transform.Translate(-movement / 10, movement / 10, 0);
        }
        else if (aim == new Vector2(1, -1))
        {
            //shoot bottom right
            transform.Translate(movement / 10, -movement / 10, 0);
        }
        else if (aim == new Vector2(-1, -1))
        {
            //shoot bottom left
            transform.Translate(-movement / 10, -movement / 10, 0);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != gun.transform.parent.gameObject)
        {
            Destroy(gameObject);
        }
    }

}


