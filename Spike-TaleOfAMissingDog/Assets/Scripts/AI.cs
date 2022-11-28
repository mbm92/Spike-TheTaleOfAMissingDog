using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class AI : MonoBehaviour
{

    private GameObject player;
    [SerializeField] private float speed = 2;
    private float distance;
    // Start is called before the first frame update
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

        distance = Vector2.Distance(transform.position, player.transform.position);
        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

    }
}
