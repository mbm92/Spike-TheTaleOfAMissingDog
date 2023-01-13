using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

using Debug = UnityEngine.Debug;

public class EnemyAttack : MonoBehaviour
{
    public float enemyCooldown = 2;
    public float damage = 6;

    private bool playerinrange = false; // this could lead to a problem when restarting game and this is not set to false,
    public bool canattack = true;


    private void Update()
    {
        if (playerinrange && canattack)
        {
            GameObject.Find("Player").GetComponent<PlayerHealth>().currenthealth -= damage;
            StartCoroutine(AttackCooldown());
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerinrange = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerinrange = false;
        }
    }
    IEnumerator AttackCooldown()
    {
        canattack = false;
        yield return new WaitForSeconds(enemyCooldown);
        canattack = true;
    }

    
}
