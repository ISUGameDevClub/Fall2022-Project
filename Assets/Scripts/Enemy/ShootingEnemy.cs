using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{

    public bool isEnemyWalking;
    public bool isEnemyShooting;
    private float playerPosX;
    private float playerPosY;

    [SerializeField] private float shootingDistance;

    // Start is called before the first frame update
    void Start()
    {
        isEnemyShooting = false;
        isEnemyWalking = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosX = GameObject.FindWithTag("Player").transform.position.x;
        playerPosY = GameObject.FindWithTag("Player").transform.position.y;

        if (Mathf.Abs(playerPosX - gameObject.transform.position.x) <= shootingDistance && Mathf.Abs(playerPosY - gameObject.transform.position.y) <= shootingDistance)
        {
            isEnemyWalking = false;
            isEnemyShooting = true;
            //start shooting
        }

        else
        {
            isEnemyWalking = true;
            isEnemyShooting = false;
            //start walking
        }
    }
}
