using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{

    [SerializeField] GameObject[] bulletPrefab;
    Health playerHP;
    // Start is called before the first frame update
    void Start()
    {
        playerHP = transform.parent.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
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
            //make bullet fly forward
            if (bulletToSpawn==2)
            {
            
                GameObject bullet2 = Instantiate(bulletPrefab[bulletToSpawn], position, Quaternion.identity );
                GameObject bullet3 = Instantiate(bulletPrefab[bulletToSpawn], position,Quaternion.identity );
                bullet.GetComponent<projectile_player_juggernaut>().gun = gameObject;
                Quaternion.SetFromToRotation(new Vector2(1,1),new Vector2(1,-1));
                bullet2.GetComponent<projectile_player_juggernaut>().gun = gameObject;
                bullet3.GetComponent<projectile_player_juggernaut>().gun = gameObject;
                bullet.GetComponent<projectile_player_juggernaut>().gun.transform.localPosition = new Vector2(1, 1); 
                bullet2.GetComponent<projectile_player_juggernaut>().gun.transform.localPosition = new Vector2(1, 1);                
                bullet3.GetComponent<projectile_player_juggernaut>().gun.transform.localPosition = new Vector2(1, 1);  
            }
            else if (bulletToSpawn==0)
            {
                bullet.GetComponent<Projectile_Player>().gun = gameObject;
            }
        }
    }
}
