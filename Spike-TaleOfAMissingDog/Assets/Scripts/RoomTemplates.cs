using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTemplates : MonoBehaviour
{
    public List<GameObject> bottomRooms;
    public List<GameObject> topRooms;
    public List<GameObject> rightRooms;
    public List<GameObject> leftRooms;


    public GameObject closedRoom;
    
    public List<GameObject> rooms;

    private float waitTime = 3f;
    private bool spawnedBoss;
    public GameObject boss;

    private Monsters monsters;

    // should spawn a locked door in the last room
    // should spawn a key in on other room on the map. 
    // collect key, should be saved in inventory so when collide with the locked door, it should open. 
    // and player can progress to next level. 

    void Start()
    {
        monsters = GameObject.FindGameObjectWithTag("Monsters").GetComponent<Monsters>();
        var rand =  Random.Range(0,monsters.monsters.Count-1);

        boss = monsters.monsters[rand];
    }


    void Update()
    {
        SpawnBoss();
    }

    void SpawnBoss()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    var roomPos = rooms[i].transform.position;
                    Debug.Log(roomPos);
                    Debug.Log(rooms[i]);
                    Instantiate(boss, roomPos, Quaternion.identity);
                    spawnedBoss = true;
                }
            }
        }
        else if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
    }
}
