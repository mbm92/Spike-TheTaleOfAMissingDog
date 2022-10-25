using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // Top = 1
    // Right = 2
    // left = 3
    // Bottom = 4

    // a connection of two openings would result in 5


    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    public float waitTime = 4f;

    void Start()
    {
        // destroy this spawnPoint after 4 sec.
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        // call spawn function with a timeDelay (0.1 sec)
        Invoke("Spawn", 0.1f);
    }

    void Spawn()
    {
        if (spawned == false)   // controls rooms to spawn
        {

            switch (openingDirection)
            {
                case 1:
                    // need to spawn a room with a TopOpening door
                    rand = Random.Range(0, templates.topRooms.Count);
                    Instantiate(templates.topRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 2:
                    // neet to spawn a room with a Right opening door
                    rand = Random.Range(0, templates.rightRooms.Count);
                    Instantiate(templates.rightRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 3:
                    // need to spwan a room with a Left opening door
                    rand = Random.Range(0, templates.leftRooms.Count);
                    Instantiate(templates.leftRooms[rand], transform.position, Quaternion.identity);
                    break;
                case 4:
                    // need to spawn a room with a Bottom opening door
                    rand = Random.Range(0, templates.bottomRooms.Count);
                    Instantiate(templates.bottomRooms[rand], transform.position, Quaternion.identity);
                    break;
                default: 
                    break;
            }
            spawned = true;
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if (other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                //if (!other.CompareTag("StartRoom"))
                //{
                //    Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                //}
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }

}
