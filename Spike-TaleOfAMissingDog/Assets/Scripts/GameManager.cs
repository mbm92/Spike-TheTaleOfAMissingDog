using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using TMPro;
using System.Reflection;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private GameObject player;

    private void Awake()
    {
        if (GameManager.instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);

        creatures_counter = GameObject.Find("CreaturesTamedDisplay").GetComponent<TextMeshProUGUI>();
        key_display = GameObject.Find("KeyImage").GetComponent<Image>();
    }

    //resources


    // Level State 
    public bool bossKilled = false;
    public bool keyCollected = false;

    public float health_drop_rate = 1f / 10f;
    public GameObject health_drop;

    



    // references
    //public RoomTemplates roomTemplates;
    //public MonstersTemplate monstersTemplate;
    // public Player; - need a ref to the player gameObject



    // Logic
    public int experience;
    public int creatures_tamed;
    public TextMeshProUGUI creatures_counter;
    public Image key_display;

    // Save State
    // what do we neeed to save? 
    /*
            
        

    */


    public void SaveState()
    {
        Debug.Log("SaveState");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("LoadState");
    }

    public void LoadNextScene()
    {
        if(!player) player = GameObject.FindGameObjectWithTag("Player");
        DontDestroyOnLoad(player);  // is this what needs to be done?
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("ForestDay");
    }

    public void Update()
    {
        creatures_counter.text = "Creatures Tamed: " + creatures_tamed.ToString();
        if (keyCollected)
        {
            key_display.color = new Color32(255, 255, 255, 255);
        }
        else
        {
            key_display.color = new Color32(114, 114, 114, 255);
        }
        
    }
}
