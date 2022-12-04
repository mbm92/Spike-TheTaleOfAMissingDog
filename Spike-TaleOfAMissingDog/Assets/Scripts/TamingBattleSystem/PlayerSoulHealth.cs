using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulHealth : MonoBehaviour
{
    public int HP;

    public int MaxHp;

    public void TakeDamage(int dmg)
    {
        HP -= dmg;

        if (HP <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("Player Has Died");
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
