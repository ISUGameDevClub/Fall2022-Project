using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    public GameObject player;
    public float distanceTrigger;
    public float spawnWaitTime;
    public Animator boxAnimator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boxAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Vector2.Distance(this.transform.position, player.transform.position) < distanceTrigger)
       {
            StartCoroutine(SpawnEnemies(spawnWaitTime));
       }
    }

    private IEnumerator SpawnEnemies(float waitTime)
    {
        while (waitTime > 0)
        {
            Instantiate(enemyToSpawn, new Vector3(transform.position.x - 5, transform.position.y, transform.position.z), Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
