using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject[] bulletPrefab;
    [SerializeField] GameObject[] shootSounds;
    Health playerHP;
    [SerializeField] Animator playerUpper;
    [SerializeField]
    AudioClip
        specialReady;
    [SerializeField]
    AudioClip
        specialNull;
    [SerializeField]
    GameObject
        specialPrefab;
    [SerializeField]
    GameObject
        smokePrefab;
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
        if(Input.GetMouseButton(0) && canShootNow == true && Time.timeScale != 0)
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
                GameObject bul1 = Instantiate(bulletPrefab[bulletToSpawn], transform.position, Quaternion.identity);
                bul1.GetComponent<Attack>().moveDirection = GetComponent<Aiming>().aimDirection;

                float ang1 = Vector2.SignedAngle(Vector2.right, bul1.GetComponent<Attack>().moveDirection);
                ang1 += 20;
                bul1.GetComponent<Attack>().moveDirection = (Vector2)(Quaternion.Euler(0, 0, ang1) * Vector2.right);

                GameObject bul2 = Instantiate(bulletPrefab[bulletToSpawn], transform.position, Quaternion.identity);
                bul2.GetComponent<Attack>().moveDirection = GetComponent<Aiming>().aimDirection;

                float ang2 = Vector2.SignedAngle(Vector2.right, bul2.GetComponent<Attack>().moveDirection); 
                ang2 -= 20;
                bul2.GetComponent<Attack>().moveDirection = (Vector2)(Quaternion.Euler(0, 0, ang2) * Vector2.right);
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
            if (bulletPrefab[bulletToSpawn] != null)
            {
                if (bulletToSpawn < 4)
                {
                    AttackAnimation(GetComponent<Aiming>().GetCurrentAim(), "revolver");
                }
                else if (bulletToSpawn > 6)
                {
                    AttackAnimation(GetComponent<Aiming>().GetCurrentAim(), "grenade");
                }
                else
                {
                    AttackAnimation(GetComponent<Aiming>().GetCurrentAim(), "whip");
                }
                GameObject bullet = Instantiate(bulletPrefab[bulletToSpawn], position, Quaternion.identity);
                bullet.GetComponent<Attack>().moveDirection = GetComponent<Aiming>().aimDirection;

                if (shootSounds[bulletToSpawn] != null)
                {
                    Instantiate(shootSounds[bulletToSpawn], transform.position, Quaternion.identity);
                }
                StartCoroutine(shotDelay(bullet.GetComponent<Attack>().attackCooldown));
            }
        }

        //Right Click
        if (Input.GetMouseButton(1) && specialCanShootNow == true && Time.timeScale != 0)
        {

            int bulletToSpawn = 10;
            if (playerHP.playerHealth.Equals("bouncer"))
            {
                bulletToSpawn = 11;
                StartCoroutine(BouncerShots(bulletToSpawn));
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
                GameObject player = FindObjectOfType<PlayerMovement>().gameObject;
                LayerMask mask = LayerMask.GetMask("Ground");

                Vector2 dir;
                if (GetComponentInParent<PlayerMovement>(false).getFlipped() == true)
                {
                    dir = Vector2.right;
                }
                else
                {
                    dir = Vector2.left;
                }

                RaycastHit2D hit = Physics2D.Raycast(player.transform.position, dir, 4, mask);
                if(hit.collider == null)
                {
                    GameObject smoke = Instantiate(smokePrefab, (Vector2)player.transform.position + dir * 4, Quaternion.identity,null);
                    Destroy(smoke, 1);
                    player.transform.position = (Vector2)player.transform.position + dir * 4;
                }
                else
                {
                    GameObject smoke = Instantiate(smokePrefab, hit.point, Quaternion.identity,null);
                    Destroy(smoke, 1);
                    player.transform.position = hit.point;
                }
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

            if (bulletPrefab[bulletToSpawn] != null)
            {
                if (bulletToSpawn < 14)
                {
                    AttackAnimation(GetComponent<Aiming>().GetCurrentAim(), "revolver");
                }
                else if (bulletToSpawn > 16)
                {
                    AttackAnimation(GetComponent<Aiming>().GetCurrentAim(), "grenade");
                }
                else
                {
                    AttackAnimation(GetComponent<Aiming>().GetCurrentAim(), "whip");
                }
                //spawn bullet here
                if (bulletToSpawn != 10)
                {
                    specialCanShootNow = false;
                    GameObject bullet = Instantiate(bulletPrefab[bulletToSpawn], transform.position, Quaternion.identity);

                    specialPrefab.SetActive(false);
                    bullet.GetComponent<Attack>().moveDirection = GetComponent<Aiming>().aimDirection;
                    if (shootSounds[bulletToSpawn] != null)
                    {
                        Instantiate(shootSounds[bulletToSpawn], transform.position, Quaternion.identity);
                    }
                    StartCoroutine(specialShotDelay(bullet.GetComponent<Attack>().attackCooldown));
                }
            }
        }
        else if (Input.GetMouseButtonDown(1) && Time.timeScale != 0)
        {
            GetComponent<AudioSource>().clip = specialNull;
            GetComponent<AudioSource>().Play();
        }
        

    }
    void AttackAnimation(int direction,string attackType)
    {
        if(direction == 0)
        {
            if (attackType.Equals("revolver"))
            {
                playerUpper.SetTrigger("ShootUp");
            }
            if (attackType.Equals("whip"))
            {
                playerUpper.SetTrigger("WhipUpRight");
            }
            if (attackType.Equals("grenade"))
            {
                playerUpper.SetTrigger("ThrowOver");
            }
        }
        else if(direction == 1)
        {
            if (attackType.Equals("revolver"))
            {
                playerUpper.SetTrigger("ShootUpRight");
            }
            if (attackType.Equals("whip"))
            {
                playerUpper.SetTrigger("WhipUpRight");
            }
            if (attackType.Equals("grenade"))
            {
                playerUpper.SetTrigger("ThrowOver");
            }
        }
        else if (direction == 2)
        {
            if (attackType.Equals("revolver"))
            {
                playerUpper.SetTrigger("ShootRight");
            }
            if (attackType.Equals("whip"))
            {
                playerUpper.SetTrigger("WhipRight");
            }
            if (attackType.Equals("grenade"))
            {
                playerUpper.SetTrigger("ThrowOver");
            }
        }
        else if (direction == 3)
        {
            if (attackType.Equals("revolver"))
            {
                playerUpper.SetTrigger("ShootDownRight");
            }
            if (attackType.Equals("whip"))
            {
                playerUpper.SetTrigger("WhipDownRight");
            }
            if (attackType.Equals("grenade"))
            {
                playerUpper.SetTrigger("ThrowUnder");
            }
        }
        else if (direction == 4)
        {
            if (attackType.Equals("revolver"))
            {
                playerUpper.SetTrigger("ShootDown");
            }
            if (attackType.Equals("whip"))
            {
                playerUpper.SetTrigger("WhipDownRight");
            }
            if (attackType.Equals("grenade"))
            {
                playerUpper.SetTrigger("ThrowUnder");
            }
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
        GetComponent<AudioSource>().clip = specialReady;
        GetComponent<AudioSource>().Play();
        specialPrefab.SetActive(true);
        specialCanShootNow = true;
    }
}
