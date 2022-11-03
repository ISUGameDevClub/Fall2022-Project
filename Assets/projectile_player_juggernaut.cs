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
    public string shotOrder;

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
       
        if (aim == new Vector2(0.78f, 0.413f))
        { 
            if(shotOrder=="Top")
            {
                transform.Translate(movement/10, movement / 40, 0); 
            }
            else if(shotOrder=="Bottom")
            {
                transform.Translate(movement / 10, -movement / 40, 0);
            }
            else{
            //shoot right 
            transform.Translate(movement / 10, 0, 0);
            }
            
        }
        else if (aim == new Vector2(0, 1))
        {
             if(shotOrder=="Top")
            {
                transform.Translate(-movement/40, movement / 10, 0); 
            }
            else if(shotOrder=="Bottom")
            {
                transform.Translate(movement / 40, movement / 10, 0);
            }
            else{
            //shoot up 
            transform.Translate(0, movement / 10, 0);
            }
            
             
        }
        else if (aim == new Vector2(-0.78f, 0.413f))
        {
             if(shotOrder=="Top")
            {
                transform.Translate(-movement/10, movement / 40, 0); 
            }
            else if(shotOrder=="Bottom")
            {
                transform.Translate(-movement / 10, -movement / 40, 0);
            }
            else{
            //shoot left
            transform.Translate(-movement / 10, 0, 0);
            }

        }
        else if (aim == new Vector2(0, -1))
        {
            if(shotOrder=="Top")
            {
                transform.Translate(movement/40, -movement / 10, 0); 
            }
            else if(shotOrder=="Bottom")
            {
                transform.Translate(-movement / 40, -movement / 10, 0);
            }
            else{
            //shoot down
            transform.Translate(0, -movement / 10,  0);
            }

        }
        else if (aim == new Vector2(1, 1)) //Need to tighten the bullets for all angles below
        {
            if(shotOrder=="Top")
            {
                transform.Translate(0, movement / 10, 0); 
            }
            else if(shotOrder=="Bottom")
            {
                transform.Translate(movement / 10, 0, 0);
            }
            else{
            //shoot top right
            transform.Translate(movement/10, movement / 10, 0);
            }

        }
        else if (aim == new Vector2(-1, 1))
        {
            if(shotOrder=="Top")
            {
                transform.Translate(0, movement / 10, 0); 
            }
            else if(shotOrder=="Bottom")
            {
                transform.Translate(-movement / 10, 0, 0);
            }
            else{
            //shoot top left
            transform.Translate(-movement / 10, movement / 10, 0);
            }

        }
        else if (aim == new Vector2(1, -1))
        {
            if(shotOrder=="Top")
            {
                transform.Translate(movement/10, 0, 0); 
            }
            else if(shotOrder=="Bottom")
            {
                transform.Translate(0, -movement / 10, 0);
            }
            else{
            //shoot bottom right
            transform.Translate(movement / 10, -movement / 10, 0);
            }

        }
        else if (aim == new Vector2(-1, -1))
        {
            if(shotOrder=="Top")
            {
                transform.Translate(-movement/10, 0, 0); 
            }
            else if(shotOrder=="Bottom")
            {
                transform.Translate(0, -movement / 10, 0);
            }
            else{
            //shoot bottom left
            transform.Translate(-movement / 10, -movement / 10, 0);
            }

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


