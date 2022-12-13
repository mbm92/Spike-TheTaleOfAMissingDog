using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;


public class Enemyhealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float health;

    public Slider slider;
    GameObject health_drop;
    float health_drop_rate;

    private float TameLimit = 5;
    private GameObject player;

    float distance;
    public float Tametimer;

    private GameManager gameManager;

    private TextMeshProUGUI TameText;

    private Renderer BodyComponent;
    private Renderer HeadComponent;


    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        health_drop_rate = gameManager.health_drop_rate;
        if (health_drop_rate == null){
            health_drop_rate = 1f / 10f;
        }
        health_drop = gameManager.health_drop;
        if (gameObject.tag == "Boss")
        {
            maxHealth = Random.Range(400, 500);
        }

        health = maxHealth;
        slider.value = CalculateHealth();
        player = GameObject.FindGameObjectWithTag("Player");
        TameText = GameObject.Find("TameText").GetComponent<TextMeshProUGUI> ();
        //BodyComponent = gameObject.transform.Find("Body").GetComponent<Renderer>();
        //HeadComponent = BodyComponent.transform.Find("Head").GetComponent<Renderer>();
    }

    void Update()
    {
        if (player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        slider.value = CalculateHealth();

        if (health <= 0 )
        {
            if (gameObject.tag == "Boss")
            {
                gameManager.bossKilled = true;
                GetComponent<AI>().speed = 0;
                Destroy(gameObject);
            }
            else
            {
                GetComponent<AI>().speed = 0;
                var creaturePos = gameObject.transform.position;
                //gameObject.Move(Vector3.zero,false,false);
                //WaitForSeconds(3);
                Tametimer += Time.deltaTime;
                if (Tametimer < TameLimit)
                {
                    //StartCoroutine(Blink());
                    if (gameManager.creatures_tamed == 0)
                    {
                        TameText.color = new Color32(0, 0, 0, 255);
                    }
                    distance = Vector2.Distance(creaturePos, player.transform.position);
                    if (distance < 2 && Input.GetKeyDown(KeyCode.E))
                    {
                        gameManager.creatures_tamed += 1;
                        Destroy(gameObject);
                        TameText.color = new Color32(0, 0, 0, 0);
                    }

                }

                else
                {
                    Destroy(gameObject);
                    TameText.color = new Color32(0, 0, 0, 0);
                    if (Random.Range(0f, 1f) <= health_drop_rate)
                    {
                        Instantiate(health_drop, transform.position, health_drop.transform.rotation);
                    }
                }
            }
        }

    }
    float CalculateHealth()
    {
        return health/ maxHealth;
    }

    //IEnumerator Blink()
    //{
        
    //    BodyComponent.enabled = false;
    //    if (HeadComponent != null)
    //    {
    //        HeadComponent.enabled = false;
    //    }
    //    //Component.enabled = false;
    //    yield return new WaitForSeconds(1f);
        
    //    BodyComponent.enabled = true;
    //    if (HeadComponent != null)
    //    {
    //        HeadComponent.enabled = true;
    //    }
    //    yield return new WaitForSeconds(1f);

    //}
}
