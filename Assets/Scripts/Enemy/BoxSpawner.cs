using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject enemyToSpawn;
    private GameObject player;
    public float distanceTrigger;
    public float spawnWaitTime = 2.5f;
    private Animator boxAnimator;
    private bool isSpawning;
    private ParticleSystem particleSystem;
    private AudioSource audioSource;
    public bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        boxAnimator = GetComponent<Animator>();
        isSpawning = false;
        particleSystem = GetComponentInChildren<ParticleSystem>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       if(Vector2.Distance(this.transform.position, player.transform.position) < distanceTrigger && !isSpawning)
       {
            isSpawning = true;
            StartCoroutine(SpawnEnemies(spawnWaitTime));
       }
    }

    private IEnumerator SpawnEnemies(float waitTime)
    {
        while (waitTime > 0)
        {
            boxAnimator.SetTrigger("SpawnEnemy");
            yield return new WaitForSeconds(waitTime);
        }
    }

    private void SpawnEnemy()
    {
        particleSystem.Play();
        audioSource.Play();
        if (facingRight == false)
        {
            Instantiate(enemyToSpawn, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z), Quaternion.identity);
        }
        else
        {
            Instantiate(enemyToSpawn, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z), Quaternion.identity);
        }
        
    }
}
