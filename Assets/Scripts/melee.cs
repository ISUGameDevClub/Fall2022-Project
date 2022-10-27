using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour
{
    public float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

        
    

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0.0f)
        {
            if (transform.localPosition.x == 0)
            { 
                transform.localPosition = new Vector2(-1, 0);  //stab left
            }
            else
            {
                transform.localPosition = new Vector2(0, 0);  //retract
            }
            cooldown = 1.0f;
        }

    }
}
