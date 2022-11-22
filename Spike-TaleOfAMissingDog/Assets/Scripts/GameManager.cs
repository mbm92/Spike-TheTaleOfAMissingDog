using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
    }

    //resources
   

    // Level State 
    public bool bossKilled = false;
    public bool keyCollected = false;



    // references
    //public RoomTemplates roomTemplates;
    //public MonstersTemplate monstersTemplate;
    // public Player; - need a ref to the player gameObject



    // Logic
    public int experience;

    // Save State
    // what do we neeed to save? 
    /*
            
        

    */


    public void SaveState()
    {
        Debug.Log("SaveState");
    }

    public void LoadState(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("LoadState");
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene("ForestDay");
    }
}
