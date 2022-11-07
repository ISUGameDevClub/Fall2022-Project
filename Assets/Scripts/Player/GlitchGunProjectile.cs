using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchGunProjectile : MonoBehaviour
{
    [SerializeField]
    private float timeBeforeTurnAround;

    [SerializeField]
    private float turnAroundAcceleration;

    [SerializeField]
    private bool matchTurnAroundSpeed;

    private GameObject player;

    private bool turnAround;

    enum weaponType
    {
        bullet,
        grenade
    }

    public float movement = .5f;
    public GameObject gun;
    private Vector2 aim;
    public float range = 10;
    Vector2 startPosition;
    weaponType weapon;
    private Vector3 bulletSpeed;
    private Vector3 bulletStartSpeed;
    private Vector3 bulletEndSpeed;

    // Start is called before the first frame update
    void Start()
    {
        aim = gun.transform.localPosition;
        Vector2 startPosition = transform.position;
        bulletSpeed = new Vector3(0, 0, 0);
        turnAround = false;
        player = GameObject.Find("Player");

        //needs to get type of projectile
        weapon = 0;

        if (aim == new Vector2(0.78f, 0.413f))
        {
            //shoot right 
            bulletSpeed = new Vector3(movement / 10, 0, 0);

        }
        else if (aim == new Vector2(0, 1))
        {
            //shoot up
            bulletSpeed = new Vector3(0, movement / 10, 0);
        }
        else if (aim == new Vector2(-0.78f, 0.413f))
        {
            //shoot left
            bulletSpeed = new Vector3(-movement / 10, 0, 0);
        }
        else if (aim == new Vector2(0, -1))
        {
            //shoot down
            bulletSpeed = new Vector3(0, -movement / 10, 0);
        }
        else if (aim == new Vector2(1, 1))
        {
            //shoot top right
            bulletSpeed = new Vector3(movement / 10, movement / 10, 0);
        }
        else if (aim == new Vector2(-1, 1))
        {
            //shoot top left
            bulletSpeed = new Vector3(-movement / 10, movement / 10, 0);
        }
        else if (aim == new Vector2(1, -1))
        {
            //shoot bottom right
            bulletSpeed = new Vector3(movement / 10, -movement / 10, 0);
        }
        else if (aim == new Vector2(-1, -1))
        {
            //shoot bottom left
            bulletSpeed = new Vector3(-movement / 10, -movement / 10, 0);
        }

        bulletStartSpeed = bulletSpeed;
        bulletEndSpeed = bulletSpeed;


        if (bulletEndSpeed.x != 0)
        {
            bulletEndSpeed.x = -bulletEndSpeed.x;
        }

        if (bulletEndSpeed.y != 0)
        {
            bulletEndSpeed.y = -bulletEndSpeed.y;
        }


        StartCoroutine(timeAfterShoot());

    }

    // Update is called once per frame
    void Update()
    {

        if (turnAround)
        {      

            if (matchTurnAroundSpeed)
            {
                if (bulletStartSpeed.x > 0)
                {
                    
                    if(bulletSpeed.x > bulletEndSpeed.x)
                    { 
                        bulletSpeed.x -= turnAroundAcceleration * Time.deltaTime;
                    }
                    else
                    {
                        bulletSpeed.x = bulletEndSpeed.x;
                    }
                }
                else
                {
                    if (bulletSpeed.x < bulletEndSpeed.x)
                    {
                        bulletSpeed.x += turnAroundAcceleration * Time.deltaTime;
                    }
                    else
                    {
                        bulletSpeed.x = bulletEndSpeed.x;
                    }
                   
                }

                if (bulletStartSpeed.y > 0)
                {

                    if (bulletSpeed.y > bulletEndSpeed.y)
                    {
                        bulletSpeed.y -= turnAroundAcceleration * Time.deltaTime;
                    }
                    else
                    {
                        bulletSpeed.y = bulletEndSpeed.y;
                    }
                }
                else
                {
                    if (bulletSpeed.y < bulletEndSpeed.y)
                    {
                        bulletSpeed.y += turnAroundAcceleration * Time.deltaTime;
                    }
                    else
                    {
                        bulletSpeed.y = bulletEndSpeed.y;
                    }

                }

            }

            else
            {
                if (bulletSpeed.x != bulletEndSpeed.x)
                {
                    if (bulletStartSpeed.x > 0)
                    {
                        bulletSpeed.x -= turnAroundAcceleration * Time.deltaTime;
                    }

                    else
                    {
                        bulletSpeed.x += turnAroundAcceleration * Time.deltaTime;
                    }
                }

                if (bulletSpeed.y != bulletEndSpeed.y)
                {
                    if (bulletStartSpeed.y > 0)
                    {
                        bulletSpeed.y -= turnAroundAcceleration * Time.deltaTime;
                    }

                    else
                    {
                        bulletSpeed.y += turnAroundAcceleration * Time.deltaTime;
                    }
                }
            }

            

        }

        transform.Translate(bulletSpeed);

        
    }

    //needs to throw the grenade far
    private void throwGrenade(bool direction)
    {

    }

    //need to roll grenade close
    private void underhandGrenade(bool direction)
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != gun.transform.parent.gameObject)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator timeAfterShoot()
    {
        yield return new WaitForSeconds(timeBeforeTurnAround);
        turnAround = true;
        
    }

    
}
