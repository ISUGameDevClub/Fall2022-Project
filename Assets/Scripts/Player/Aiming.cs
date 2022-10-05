using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jonah && Milo

public class Aiming : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float vert = Input.GetAxisRaw("Vertical");
        float horz = Input.GetAxisRaw("Horizontal");

        if (vert > 0 && horz == 0)
        {
            //shoot up
            transform.localPosition = new Vector2(0, 1);
        }
        else if(vert == 0 && horz > 0)
        {
            //shoot right
            transform.localPosition = new Vector2(1, 0);
        }
        else if (vert == 0 && horz < 0)
        {
            //shoot left
            transform.localPosition = new Vector2(-1, 0);
        }
        else if (vert < 0 && horz ==0)
        {
            //shoot down
            transform.localPosition = new Vector2(0, -1);
        }
        else if(vert > 0 && horz > 0)
        {
            //shoot top right
            transform.localPosition = new Vector2(1, 1);
        }
        else if (vert > 0 && horz < 0)
        {
            //shoot top left
            transform.localPosition = new Vector2(-1, 1);
        }
        else if (vert < 0 && horz > 0)
        {
            //shoot bottom right
            transform.localPosition = new Vector2(1, -1);
        }
        else if (vert < 0 && horz < 0)
        {
            //shoot bottom left
            transform.localPosition = new Vector2(-1, -1);
        }
    }
}
