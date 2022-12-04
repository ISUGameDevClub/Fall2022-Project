using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jonah && Milo

public class Aiming : MonoBehaviour
{
    public GameObject[] aimPositions;
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
        if (Time.timeScale != 0)
        {
            if (vert > 0 && horz == 0)
            {
                //shoot up
                transform.localPosition = aimPositions[0].transform.localPosition;
                aimDirection = Vector2.up;
            }
            else if (vert == 0 && horz > 0)
            {
                //shoot right
                transform.localPosition = aimPositions[2].transform.localPosition;
                aimDirection = Vector2.right;
            }
            else if (vert == 0 && horz < 0)
            {
                //shoot left
                transform.localPosition = aimPositions[2].transform.localPosition;
                aimDirection = Vector2.left;
            }
            else if (vert < 0 && horz == 0)
            {
                //shoot down

                transform.localPosition = aimPositions[4].transform.localPosition;
                aimDirection = Vector2.down;
            }
            else if (vert > 0 && horz > 0)
            {
                //shoot top right
                transform.localPosition = aimPositions[1].transform.localPosition;
                aimDirection = new Vector2(1, 1).normalized;
            }
            else if (vert > 0 && horz < 0)
            {
                //shoot top left
                transform.localPosition = aimPositions[1].transform.localPosition;
                aimDirection = new Vector2(-1, 1).normalized;
            }
            else if (vert < 0 && horz > 0)
            {
                //shoot bottom right
                transform.localPosition = aimPositions[3].transform.localPosition;
                aimDirection = new Vector2(1, -1).normalized;
            }
            else if (vert < 0 && horz < 0)
            {
                //shoot bottom left
                transform.localPosition = aimPositions[3].transform.localPosition;
                aimDirection = new Vector2(-1, -1).normalized;
            }
            else if (vert == 0 && horz == 0)
            {
                if (GetComponentInParent<PlayerMovement>(false).getFlipped() == true)
                {
                    //shoot right
                    transform.localPosition = aimPositions[2].transform.localPosition;
                    aimDirection = Vector2.right;
                }
                else
                {
                    //shoot left
                    transform.localPosition = aimPositions[2].transform.localPosition;
                    aimDirection = Vector2.left;
                }
            }
        }
        if (!GetComponentInParent<PlayerMovement>(false).getFlipped())
        {
            transform.localPosition = new Vector2(-transform.localPosition.x, transform.localPosition.y);
        }
    }
}
