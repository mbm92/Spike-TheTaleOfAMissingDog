using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTemplate : MonoBehaviour
{

    public List<GameObject> commenObjects;

    public List<GameObject> uncommenObjects;

    public List<GameObject> rareObjects;


    public List<Vector2> spawnPoints;

    private float waitTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObjects()
    {
        if (waitTime <= 0)
        {
            // do some logic here?
        }
    }
}
