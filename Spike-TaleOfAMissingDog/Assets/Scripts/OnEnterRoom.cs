using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class OnEnterRoom : MonoBehaviour
{

    [CanBeNull] public GameObject entranceTop, entranceBottom, entranceLeft, entranceRight;
    
    public Vector3 offset = new Vector3(1, 0.5f, 0); // this odffset should properly change depending on which entrancePoint

    private Rigidbody2D rigidbody;

    // needs logic to get info about where player came from, to know which entrance to set to starting/entraencePosition


    [SerializeField] public SceneInfo SceneInfo;


    void Awake()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // get(sceneInfo.lastTransistionPointInfo)
        // Vector3 entrancePosition = entrence corresponding to lastTransitiencePointInfo
        Vector3 entrancePosition = entranceTop.transform.position + offset;
        rigidbody.position = entrancePosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
