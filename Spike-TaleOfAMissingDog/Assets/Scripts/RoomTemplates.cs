using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Cinemachine.Utility;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

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
    private GameObject boss;
    public GameObject doorWay;
    public GameObject key;

    private MonstersTemplate monstersTemplate;

    // should spawn a locked door in the last room
    // should spawn a key in on other room on the map. 
    // collect key, should be saved in inventory so when collide with the locked door, it should open. 
    // and player can progress to next level. 

    void Start()
    {
        monstersTemplate = GameObject.FindGameObjectWithTag("Monsters").GetComponent<MonstersTemplate>();
        var rand =  Random.Range(0,monstersTemplate.bossMonsters.Count-1);

        boss = monstersTemplate.bossMonsters[rand];
    }


    void Update()
    {
        CreateBossRoom();
    }

    void CreateBossRoom()
    {
        if (waitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    var roomPos = rooms[i].transform.position;
                    Debug.Log(roomPos);
                    Debug.Log(rooms[i].name);
                    SpawnBoss(roomPos);
                    SpawnRuneCircle(roomPos);
                    SpawnKey(roomPos);
                }
            }
        }
        else if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
    }

    void SpawnBoss(Vector3 roomPos)
    {
        spawnedBoss = true;
        Instantiate(boss, roomPos, Quaternion.identity);
    }

    void SpawnKey(Vector3 bossRoomPos)
    {
        Vector3 pivot = new Vector3();  // pivot = (0,0,0) = ForestStartRoom vector position

        if (waitTime <= 0)
        {
            foreach (GameObject room in rooms)
            {
                if (pivot == Vector3.zero) // check if pivot is set. 
                {
                    Debug.Log("setting pivot to start pos");
                    pivot = room.transform.position;    // set start pivot
                }

                var currentRoomDistance = (room.transform.position - bossRoomPos).magnitude;   // calculate distance between vectors
                var pivotDistance = (pivot - bossRoomPos).magnitude;

                if (currentRoomDistance >= pivotDistance)   // if currentRoom distance is greater then pivot
                {
                    pivot = room.transform.position;    // set pivot to currentRoom position
                }
            }
            Instantiate(key, pivot, Quaternion.identity);
        }
    }

    void SpawnRuneCircle(Vector3 roomPos)
    {
        Instantiate(doorWay, roomPos, Quaternion.identity);
    }
}
