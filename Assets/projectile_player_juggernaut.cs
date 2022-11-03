using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile_player_juggernaut : MonoBehaviour
{
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

    // Start is called before the first frame update
    void Start()
    {
        aim = gun.transform.localPosition;
        Vector2 startPosition = transform.position;
        

        //needs to get type of projectile
        weapon = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // needs to despawn bullets after distance
        // needs to call grenade methods when nessary
       
        if (aim == new Vector2(1, 0))
        { 
            //shoot right 
            transform.Translate(movement / 10, 0, 0);
            
        }
        else if (aim == new Vector2(0, 1))
        {
            //shoot up
            transform.Translate(0, movement / 10, 0); 
        }
        else if (aim == new Vector2(-1, 0))
        {
            //shoot left
            transform.Translate(-movement / 10, 0, 0);
        }
        else if (aim == new Vector2(0, -1))
        {
            //shoot down
            transform.Translate(0, -movement / 10,  0);
        }
        else if (aim == new Vector2(1, 1))
        {
            //shoot top right
            transform.Translate(movement/10, movement / 10, 0);
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
        //despawn bullet after distance
//        if (Vector2.Distance(startPosition, transform.position) > range) 
  //      {
    //        Destroy(gameObject);
      //  }
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

}


