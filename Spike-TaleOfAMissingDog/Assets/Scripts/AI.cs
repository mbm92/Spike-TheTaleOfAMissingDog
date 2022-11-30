using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class AI : MonoBehaviour
{

    private GameObject player;
    [SerializeField] public float speed = 2f;
    private float distance;
    // Start is called before the first frame update

    private float attackRange = 15f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        EngagePlayer(player);

        //distance = Vector2.Distance(transform.position, player.transform.position);
        //transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void EngagePlayer(GameObject player)
    {
        var creaturePos = gameObject.transform.position;
        
        // look if player is in range
        // if player is in range MoveTowards the player. 
        // else just stand still or move in a pattern? 

        distance = Vector2.Distance(creaturePos, player.transform.position);


        if (distance > attackRange)
            return;
        else
        {
            transform.position =
                Vector2.MoveTowards(creaturePos, player.transform.position, speed * Time.fixedDeltaTime);
        }


    }
}
