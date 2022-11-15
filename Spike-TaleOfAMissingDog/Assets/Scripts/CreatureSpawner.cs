using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{

    private MonstersTemplate monstersTemplate;
    private int rand;
    private int possibilityValue;

    [SerializeField] private float radius;   // create random radius between 5 and 8? - the bigger radius the less monsterSpawnPoints
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
        monstersTemplate = GameObject.FindGameObjectWithTag("Monsters").GetComponent<MonstersTemplate>();

        radius = Random.Range(9f, 11f);

        points = PoissonDiscSampling.GeneratingPoints(radius, regionSize, transform.position, rejectionSamples);

        foreach (Vector2 point in points)
        {
            possibilityValue = Random.Range(0, 6);
            Spawn(possibilityValue, point);

            monstersTemplate.spawnPoints.Add(point);
        }
    }

    private void Spawn(int possibilityValue, Vector2 monsterSpawnPoint)
    {
        GameObject monster;

        switch (possibilityValue)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                rand = Random.Range(0, monstersTemplate.commonMonsters.Count);
                monster = monstersTemplate.commonMonsters[rand];
                monster.transform.localScale = new Vector3(0.5f, 0.5f, 0);

                Instantiate(monster, monsterSpawnPoint, Quaternion.identity);
                break;

            case 4:
            case 5:
                rand = Random.Range(0, monstersTemplate.uncommonMonsters.Count);
                monster = monstersTemplate.uncommonMonsters[rand];
                monster.transform.localScale = new Vector3(0.5f, 0.5f, 0);
                Instantiate(monster, monsterSpawnPoint, Quaternion.identity);
                break;

            case 6:
                rand = Random.Range(0, monstersTemplate.rareMonsters.Count);
                Instantiate(monstersTemplate.rareMonsters[rand], monsterSpawnPoint, Quaternion.identity);
                break;

            default:
                break;
        }
    }
}
