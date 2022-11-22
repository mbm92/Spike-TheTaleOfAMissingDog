using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObjectsSpawner : MonoBehaviour
{

    private ObjectTemplate objectTemplate;
    private int rand;
    private int possibilityValue;
    private float waitTime = 4f;

    [SerializeField] private float radius = 4;   // create random radius between 3.5 and 6.0? 
    [SerializeField] private Vector2 regionSize = new Vector2(17, 17);
    private int rejectionSamples = 30;
    // public float displayRadius = 0.15f;

    [SerializeField] private List<Vector2> points;

    // need possibility values for each rarity
    // Commen   = 0-3   = 4/7
    // uncommon = 4-5   = 2/7
    // rare     = 6     = 1/7

    // Start is called before the first frame update
    void Start()
    {
        objectTemplate = GameObject.FindGameObjectWithTag("RoomObjects").GetComponent<ObjectTemplate>();
        
        radius = Random.Range(4.0f, 6.0f); // impact how many spawnPoints there should be in the map 

        points = PoissonDiscSampling.GeneratingPoints(radius, regionSize, transform.position, rejectionSamples);

        foreach (Vector2 point in points)
        {
            possibilityValue = Random.Range(0, 6);
            Spawn(possibilityValue, point);
            objectTemplate.spawnPoints.Add(point);
        }
    }

    void Spawn(int possibilityValue, Vector2 objSpawnPoint)
    {
        switch (possibilityValue)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                rand = Random.Range(0, objectTemplate.commenObjects.Count);
                Instantiate(objectTemplate.commenObjects[rand], objSpawnPoint, Quaternion.identity);
                break;

            case 4:
            case 5:
                rand = Random.Range(0, objectTemplate.uncommenObjects.Count);
                Instantiate(objectTemplate.uncommenObjects[rand], objSpawnPoint, Quaternion.identity);
                break;

            case 6:
                rand = Random.Range(0, objectTemplate.rareObjects.Count);
                Instantiate(objectTemplate.rareObjects[rand], objSpawnPoint, Quaternion.identity);
                break;

            default:
                break;
        }
    }
}
