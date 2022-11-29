using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemyhealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    public Slider slider;

    void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    void Update()
    {
        slider.value = CalculateHealth();

        if (health <= 0 )
        {
            FindObjectOfType<AI>().GetComponent<AI>().speed = 0;
            //gameObject.Move(Vector3.zero,false,false);
            //WaitForSeconds(3);
            Destroy(gameObject);
        }

    }
    float CalculateHealth()
    {
        return health/ maxHealth;
    }
}
