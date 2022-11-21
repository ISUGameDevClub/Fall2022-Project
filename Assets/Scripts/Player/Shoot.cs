using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject[] bulletPrefab;
    [SerializeField] GameObject[] shootSounds;
    Health playerHP;
    private bool canShootNow;
    private bool specialCanShootNow;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = transform.parent.GetComponent<Health>();
        canShootNow = true;
        specialCanShootNow = true;
    }

    // Update is called once per frame
    void Update()
    {
        //left click
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
            bullet.GetComponent<Attack>().moveDirection = GetComponent<Aiming>().aimDirection;

            Instantiate(shootSounds[bulletToSpawn], transform.position, Quaternion.identity);
            StartCoroutine(shotDelay(bullet.GetComponent<Attack>().attackCooldown));
        }

        //Right Click
        if (Input.GetMouseButton(1) && specialCanShootNow == true)
        {
            specialCanShootNow = false;
            int bulletToSpawn = 10;
            if (playerHP.playerHealth.Equals("bouncer"))
            {
                StartCoroutine(BouncerShots(11));
                bulletToSpawn = 11;
            }
            else if (playerHP.playerHealth.Equals("juggernaut"))
            {
                bulletToSpawn = 12;
            }
            else if (playerHP.playerHealth.Equals("glitchgun"))
            {
                bulletToSpawn = 13;
            }
            else if (playerHP.playerHealth.Equals("windbreaker"))
            {
                bulletToSpawn = 14;
            }
            else if (playerHP.playerHealth.Equals("chillout"))
            {
                bulletToSpawn = 15;
            }
            else if (playerHP.playerHealth.Equals("yarnwhip"))
            {
                bulletToSpawn = 16;
            }
            else if (playerHP.playerHealth.Equals("moab"))
            {
                bulletToSpawn = 17;
            }
            else if (playerHP.playerHealth.Equals("snowbomb"))
            {
                bulletToSpawn = 18;
            }
            else if (playerHP.playerHealth.Equals("candrew"))
            {
                bulletToSpawn = 19;
            }

            //spawn bullet here
            GameObject bullet = Instantiate(bulletPrefab[bulletToSpawn], transform.position, Quaternion.identity);
            bullet.GetComponent<Attack>().moveDirection = GetComponent<Aiming>().aimDirection;

            //Instantiate(shootSounds[bulletToSpawn], transform.position, Quaternion.identity);
            StartCoroutine(specialShotDelay(bullet.GetComponent<Attack>().attackCooldown));
        }
    }

    private IEnumerator BouncerShots(int bulletToSpawn)
    {
        yield return new WaitForSeconds(.1f);
        GameObject bullet = Instantiate(bulletPrefab[bulletToSpawn], transform.position, Quaternion.identity);
        bullet.GetComponent<Attack>().moveDirection = GetComponent<Aiming>().aimDirection;
        //Instantiate(shootSounds[bulletToSpawn], transform.position, Quaternion.identity);
        yield return new WaitForSeconds(.1f);
        GameObject bullet2 = Instantiate(bulletPrefab[bulletToSpawn], transform.position, Quaternion.identity);
        bullet2.GetComponent<Attack>().moveDirection = GetComponent<Aiming>().aimDirection;
        //Instantiate(shootSounds[bulletToSpawn], transform.position, Quaternion.identity);
    }

    private IEnumerator shotDelay(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canShootNow = true;
    }

    private IEnumerator specialShotDelay(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        specialCanShootNow = true;
    }
}
