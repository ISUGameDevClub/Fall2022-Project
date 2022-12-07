using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Jonah && Milo

public class Aiming : MonoBehaviour
{
    public bool p2;
    public GameObject[] aimPositions;
    [SerializeField] SpriteRenderer torsoSprite;
    int currentAim;
    [HideInInspector]
    public Vector2 aimDirection;
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float vert;
        float horz;
        if (!p2)
        {
            vert = Input.GetAxisRaw("Vertical");
            horz = Input.GetAxisRaw("Horizontal");
        }
        else
        {
            vert = Input.GetAxisRaw("Vertical2");
            horz = Input.GetAxisRaw("Horizontal2");
        }

        if (Time.timeScale != 0)
        {
            int weaponType;

            if (health != null && (health.playerHealth.Equals("") || health.playerHealth.Equals("bouncer") || health.playerHealth.Equals("juggernaut") || health.playerHealth.Equals("glitchgun")))
            {
                weaponType = 0;
            }
            else if(health != null && (health.playerHealth.Equals("windbreaker") || health.playerHealth.Equals("chillout") || health.playerHealth.Equals("yarnwhip")))
            {
                weaponType = 1;
            }
            else
            {
                weaponType = 2;
            }

            if (vert > 0 && horz == 0)
            {
                //shoot up
                currentAim = 0;
                if(weaponType == 0)
                    transform.localPosition = aimPositions[0].transform.localPosition;
                else if(weaponType == 1)
                    transform.localPosition = aimPositions[5].transform.localPosition;
                else
                    transform.localPosition = aimPositions[8].transform.localPosition;
                aimDirection = Vector2.up;
            }
            else if (vert == 0 && horz > 0)
            {
                //shoot right

                currentAim = 2;
                if (weaponType == 0)
                    transform.localPosition = aimPositions[2].transform.localPosition;
                else if (weaponType == 1)
                    transform.localPosition = aimPositions[6].transform.localPosition;
                else
                    transform.localPosition = aimPositions[8].transform.localPosition;
                aimDirection = Vector2.right;
            }
            else if (vert == 0 && horz < 0)
            {
                //shoot left

                currentAim = 2;
                if (weaponType == 0)
                    transform.localPosition = aimPositions[2].transform.localPosition;
                else if (weaponType == 1)
                    transform.localPosition = aimPositions[6].transform.localPosition;
                else
                    transform.localPosition = aimPositions[8].transform.localPosition;
                aimDirection = Vector2.left;
            }
            else if (vert < 0 && horz == 0)
            {
                //shoot down

                currentAim = 4;
                if (weaponType == 0)
                    transform.localPosition = aimPositions[4].transform.localPosition;
                else if (weaponType == 1)
                    transform.localPosition = aimPositions[7].transform.localPosition;
                else
                    transform.localPosition = aimPositions[9].transform.localPosition;
                aimDirection = Vector2.down;
            }
            else if (vert > 0 && horz > 0)
            {
                //shoot top right

                currentAim = 1;
                if (weaponType == 0)
                    transform.localPosition = aimPositions[1].transform.localPosition;
                else if (weaponType == 1)
                    transform.localPosition = aimPositions[5].transform.localPosition;
                else
                    transform.localPosition = aimPositions[8].transform.localPosition;
                aimDirection = new Vector2(1, 1).normalized;
            }
            else if (vert > 0 && horz < 0)
            {
                //shoot top left

                currentAim = 1;
                if (weaponType == 0)
                    transform.localPosition = aimPositions[1].transform.localPosition;
                else if (weaponType == 1)
                    transform.localPosition = aimPositions[5].transform.localPosition;
                else
                    transform.localPosition = aimPositions[8].transform.localPosition;
                aimDirection = new Vector2(-1, 1).normalized;
            }
            else if (vert < 0 && horz > 0)
            {
                //shoot bottom right
                currentAim = 3;
                if (weaponType == 0)
                    transform.localPosition = aimPositions[3].transform.localPosition;
                else if (weaponType == 1)
                    transform.localPosition = aimPositions[7].transform.localPosition;
                else
                    transform.localPosition = aimPositions[9].transform.localPosition;
                aimDirection = new Vector2(1, -1).normalized;
            }
            else if (vert < 0 && horz < 0)
            {
                //shoot bottom left
                currentAim = 3;
                if (weaponType == 0)
                    transform.localPosition = aimPositions[3].transform.localPosition;
                else if (weaponType == 1)
                    transform.localPosition = aimPositions[7].transform.localPosition;
                else
                    transform.localPosition = aimPositions[9].transform.localPosition;
                aimDirection = new Vector2(-1, -1).normalized;
            }
            else if (vert == 0 && horz == 0)
            {
                if (GetComponentInParent<PlayerMovement>(false).getFlipped() == true)
                {
                    //shoot right

                    currentAim = 2;
                    if (weaponType == 0)
                        transform.localPosition = aimPositions[2].transform.localPosition;
                    else if (weaponType == 1)
                        transform.localPosition = aimPositions[6].transform.localPosition;
                    else
                        transform.localPosition = aimPositions[8].transform.localPosition;
                    aimDirection = Vector2.right;
                }
                else
                {
                    //shoot left

                    currentAim = 2;
                    if (weaponType == 0)
                        transform.localPosition = aimPositions[2].transform.localPosition;
                    else if (weaponType == 1)
                        transform.localPosition = aimPositions[6].transform.localPosition;
                    else
                        transform.localPosition = aimPositions[8].transform.localPosition;
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
