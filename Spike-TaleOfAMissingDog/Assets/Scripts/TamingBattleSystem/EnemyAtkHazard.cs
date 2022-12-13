using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAtkHazard : MonoBehaviour
{

    public int Damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerSoulWillpower>())
        {
            other.GetComponent<PlayerSoulWillpower>().TakeDamage(Damage);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
