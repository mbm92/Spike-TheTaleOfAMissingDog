using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

using Debug = UnityEngine.Debug;

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
            FindObjectOfType<GameManager>().RestartGame();
        }

    }

    float CalculateHealth()
    {
        return currenthealth / maxHealth;
    }

    void OnTriggerEnter2D(Collider2D drop)
    {
        if (drop.gameObject.CompareTag("HealthDrop"))
        {
            
            float addheal = drop.gameObject.GetComponent<heal_amount>().HealAmount;
            currenthealth = currenthealth + addheal;
            if (currenthealth >= maxHealth)
            {
                currenthealth = maxHealth;
            }
            
            Destroy(drop.gameObject);
        }
    }
}
