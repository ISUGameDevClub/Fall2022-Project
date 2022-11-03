using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject[] bulletPrefab;
    Health playerHP;

    public float shotDelayValue = .05f;
    private bool canShootNow;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = transform.parent.GetComponent<Health>();
        canShootNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && canShootNow == true)
        {
            canShootNow = false;
            Vector2 position = gameObject.transform.position;
            int bulletToSpawn = 0;
            if (playerHP.playerHealth.Equals("bouncer")){
                bulletToSpawn = 1;
            }
            else if (playerHP.playerHealth.Equals("juggernaut"))
            {
                bulletToSpawn = 2;
            }
            else if (playerHP.playerHealth.Equals("glitchgun"))
            {
                bulletToSpawn = 3;
            }
            else if (playerHP.playerHealth.Equals("windbreaker"))
            {
                bulletToSpawn = 4;
            }
            else if (playerHP.playerHealth.Equals("chillout"))
            {
                bulletToSpawn = 5;
            }
            else if (playerHP.playerHealth.Equals("yarnwhip"))
            {
                bulletToSpawn = 6;
            }
            else if (playerHP.playerHealth.Equals("moab"))
            {
                bulletToSpawn = 7;
            }
            else if (playerHP.playerHealth.Equals("snowbomb"))
            {
                bulletToSpawn = 8;
            }
            else if (playerHP.playerHealth.Equals("candrew"))
            {
                bulletToSpawn = 9;
            }

            //spawn bullet here
            GameObject bullet = Instantiate(bulletPrefab[bulletToSpawn], position,Quaternion.identity );

            StartCoroutine(shotDelay());

            //make bullet fly forward
            if (bulletToSpawn == 0)
            {
                bullet.GetComponent<Projectile_Player>().gun = gameObject;
            }
            if (bulletToSpawn == 1)
            {
                bullet.GetComponent<Projectile_Player>().gun = gameObject;
            }
            if (bulletToSpawn == 2)
            {
                bullet.GetComponent<Projectile_Player>().gun = gameObject;
            }
            if (bulletToSpawn == 3)
            {
                bullet.GetComponent<GlitchGunProjectile>().gun = gameObject;
            }
            if (bulletToSpawn == 4)
            {
                bullet.GetComponent<Projectile_Player>().gun = gameObject;
            }
            if (bulletToSpawn == 5)
            {
                bullet.GetComponent<Projectile_Player>().gun = gameObject;
            }
            if (bulletToSpawn == 6)
            {
                bullet.GetComponent<Projectile_Player>().gun = gameObject;
            }
            if (bulletToSpawn == 7)
            {
                bullet.GetComponent<Projectile_Player>().gun = gameObject;
            }
            if (bulletToSpawn == 8)
            {
                bullet.GetComponent<Projectile_Player>().gun = gameObject;
            }
            if (bulletToSpawn == 9)
            {
                bullet.GetComponent<Grenade_Player>().gun = gameObject;
            }
        }

    }


    private IEnumerator shotDelay()
    {
        yield return new WaitForSeconds(shotDelayValue);
        canShootNow = true;
    }
}
