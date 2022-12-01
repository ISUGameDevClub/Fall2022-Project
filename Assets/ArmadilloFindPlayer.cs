using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadilloFindPlayer : MonoBehaviour
{
    GameObject player;
    bool onRight;
    // Start is called before the first frame update
    void Start()
    {
        
       player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x > player.transform.position.x)
        {
            onRight = true;
        }

        else
        {
            onRight = false;
        }
    }


}
