using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject projectile;
    public GameObject shootSpawn;

    private GameObject player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    public void StartFight()
    {
        StartCoroutine(AttackPattern());
    }


    private IEnumerator AttackPattern()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.75f);
            Shoot(((Vector2)player.transform.position) - (Vector2)shootSpawn.transform.position);
            yield return new WaitForSeconds(1.75f);
            Shoot(((Vector2)player.transform.position + new Vector2(0, 2.5f)) - (Vector2)shootSpawn.transform.position);
            Shoot(((Vector2)player.transform.position + new Vector2(0, -2.5f)) - (Vector2)shootSpawn.transform.position);
            yield return new WaitForSeconds(1.75f);
            Shoot(player.transform.position - shootSpawn.transform.position);
            Shoot(((Vector2)player.transform.position + new Vector2(0, 5)) - (Vector2)shootSpawn.transform.position);
            Shoot(((Vector2)player.transform.position + new Vector2(0, -5)) - (Vector2)shootSpawn.transform.position);
        }
    }

    private void Shoot(Vector2 shootDir)
    {
        GameObject bul = Instantiate(projectile, shootSpawn.transform.position, Quaternion.identity);
        bul.transform.right = shootDir;
    }
}
