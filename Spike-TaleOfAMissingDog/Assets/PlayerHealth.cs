using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    
    public float maxHealth;
    public float currenthealth;
    public playerMovement player;
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = maxHealth;
        slider.value = CalculateHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = CalculateHealth();

        if (currenthealth <= 0)
        {
            player.moveSpeed = 0;
        }

    }
    float CalculateHealth()
    {
        return currenthealth / maxHealth;
    }
}
