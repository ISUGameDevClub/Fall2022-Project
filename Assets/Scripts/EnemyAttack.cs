using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script is for the enemy's 'ranged' attack.
//The player's health script already takes care of enemy melee.

//TESTING: Made and attached this script to "GenericEnemy" object for testing.

//Still need to make bullet object invisible then make it visible when it is instantiated and shot.
//Need to despawn objects a few seconds after they've been shot or when they collide with the player.
//Collider says "no camera" when "IS TRIGGER" is on because the player dies. Need to distinguish the boxcollider of a melee attack vs the range of a bullet. 

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    [Range(0.25f,1.0f)]
    float
        attackCooldown = .5f;
    private IEnumerator SwingAttack()
    {
        yield return new WaitForSeconds(attackCooldown);
    }
}
