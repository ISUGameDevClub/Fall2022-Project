using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jonah && Milo

public class Aiming : MonoBehaviour
{
    [SerializeField] Sprite[] aimingSprites;
    [SerializeField] SpriteRenderer torsoSprite;

    [HideInInspector]
    public Vector2 aimDirection;

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
            torsoSprite.sprite = aimingSprites[0];
            transform.localPosition = new Vector2(0, 1);
            aimDirection = Vector2.up;
        }
        else if(vert == 0 && horz > 0)
        {
            //shoot right
            torsoSprite.sprite = aimingSprites[2];
            transform.localPosition = new Vector2(0.78f, 0.413f);
            aimDirection = Vector2.right;
        }
        else if (vert == 0 && horz < 0)
        {
            //shoot left
            torsoSprite.sprite = aimingSprites[2];
            transform.localPosition = new Vector2(-0.78f, 0.413f);
            aimDirection = Vector2.left;
        }
        else if (vert < 0 && horz ==0)
        {
            //shoot down

            torsoSprite.sprite = aimingSprites[4];
            transform.localPosition = new Vector2(0, -1);
            aimDirection = Vector2.down;
        }
        else if(vert > 0 && horz > 0)
        {
            //shoot top right
            torsoSprite.sprite = aimingSprites[1];
            transform.localPosition = new Vector2(1, 1);
            aimDirection = new Vector2(1, 1);
        }
        else if (vert > 0 && horz < 0)
        {
            //shoot top left
            torsoSprite.sprite = aimingSprites[1];
            transform.localPosition = new Vector2(-1, 1);
            aimDirection = new Vector2(-1, 1);
        }
        else if (vert < 0 && horz > 0)
        {
            //shoot bottom right
            torsoSprite.sprite = aimingSprites[3];
            transform.localPosition = new Vector2(1, -1);
            aimDirection = new Vector2(1, -1);
        }
        else if (vert < 0 && horz < 0)
        {
            //shoot bottom left
            torsoSprite.sprite = aimingSprites[3];
            transform.localPosition = new Vector2(-1, -1);
            aimDirection = new Vector2(-1, -1);
        }
        else if(vert == 0 && horz == 0)
        {
            if( GetComponentInParent<PlayerMovement>(false).getFlipped() == true)
            {
                //shoot right
                torsoSprite.sprite = aimingSprites[2];
                transform.localPosition = new Vector2(0.78f, 0.413f);
                aimDirection = Vector2.right;
            }
            else
            {
                //shoot left
                torsoSprite.sprite = aimingSprites[2];
                transform.localPosition = new Vector2(-0.78f, 0.413f);
                aimDirection = Vector2.left;
            }
        }
    }
}
