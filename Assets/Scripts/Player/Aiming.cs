using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jonah && Milo

public class Aiming : MonoBehaviour
{
    public GameObject[] aimPositions;
    [SerializeField] SpriteRenderer torsoSprite;
    int currentAim;
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
                currentAim = 0;
                transform.localPosition = aimPositions[currentAim].transform.localPosition;
                aimDirection = Vector2.up;
            }
            else if (vert == 0 && horz > 0)
            {
                //shoot right

                currentAim = 2;
                transform.localPosition = aimPositions[currentAim].transform.localPosition;
                aimDirection = Vector2.right;
            }
            else if (vert == 0 && horz < 0)
            {
                //shoot left

                currentAim = 2;
                transform.localPosition = aimPositions[currentAim].transform.localPosition;
                aimDirection = Vector2.left;
            }
            else if (vert < 0 && horz == 0)
            {
                //shoot down

                currentAim = 4;
                transform.localPosition = aimPositions[currentAim].transform.localPosition;
                aimDirection = Vector2.down;
            }
            else if (vert > 0 && horz > 0)
            {
                //shoot top right

                currentAim = 1;
                transform.localPosition = aimPositions[currentAim].transform.localPosition;
                aimDirection = new Vector2(1, 1).normalized;
            }
            else if (vert > 0 && horz < 0)
            {
                //shoot top left

                currentAim = 1;
                transform.localPosition = aimPositions[currentAim].transform.localPosition;
                aimDirection = new Vector2(-1, 1).normalized;
            }
            else if (vert < 0 && horz > 0)
            {
                //shoot bottom right
                currentAim = 3;
                transform.localPosition = aimPositions[currentAim].transform.localPosition;
                aimDirection = new Vector2(1, -1).normalized;
            }
            else if (vert < 0 && horz < 0)
            {
                //shoot bottom left
                currentAim = 3;
                transform.localPosition = aimPositions[currentAim].transform.localPosition;
                aimDirection = new Vector2(-1, -1).normalized;
            }
            else if (vert == 0 && horz == 0)
            {
                if (GetComponentInParent<PlayerMovement>(false).getFlipped() == true)
                {
                    //shoot right

                    currentAim = 2;
                    transform.localPosition = aimPositions[currentAim].transform.localPosition;
                    aimDirection = Vector2.right;
                }
                else
                {
                    //shoot left

                    currentAim = 2;
                    transform.localPosition = aimPositions[currentAim].transform.localPosition;
                    aimDirection = Vector2.left;
                }
            }
        }
        if (!GetComponentInParent<PlayerMovement>(false).getFlipped())
        {
            transform.localPosition = new Vector2(-transform.localPosition.x, transform.localPosition.y);
        }
    }
    public int GetCurrentAim()
    {
        return currentAim;
    }
}
