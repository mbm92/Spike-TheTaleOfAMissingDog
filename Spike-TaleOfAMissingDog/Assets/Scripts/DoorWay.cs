using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class DoorWay : MonoBehaviour
{

    public SpriteMask Mask;
    private static SpriteMask _mask;
    public static Collider2D collider;

    private bool doorOpened;


    void Start()
    {
        doorOpened = false;
        Debug.Log("doorOpend? " + doorOpened);
        collider = gameObject.GetComponent<Collider2D>();
        Debug.Log("collider is enabled " + collider.isActiveAndEnabled);
        _mask = Mask;

        if (!doorOpened)
        {
            Mask.enabled = false;   // turn off runes
            
            collider.enabled = false;
            Debug.Log("collider is enabled " + collider.isActiveAndEnabled);
            Debug.Log("Door closed");
        }
        else if(doorOpened)
        {
            Mask.enabled = true;    // turns on runes
            collider.enabled = true;
            Debug.Log("Door open");
        }
    }

    public void ToggleObject()
    {
        Debug.Log("Entered ToggleMethod. door opened? " + doorOpened);
    
        _mask.enabled = true;
        collider.enabled = true;
        //collider.enabled = !collider.enabled; // if i want a toggle effect

        // should have a check to see
        // if key is collected, then enable portal collider, and spriteMask 
        // portal collider should then check if bossCreature is defeated
        // then 
        // if it is, then instansiate portal beam object, that holds a screnTransition logic.
        // 

        Debug.Log("collider is enabled?" + collider.isActiveAndEnabled);
        if (collider.isActiveAndEnabled)
        {
            Debug.Log("Door open");
            doorOpened = true;
        }
        else
        {
            Debug.Log("Door still closed");
        }
    }


    public void OnTriggerEnter2D(Collider2D player)
    {
        //sceneInfo.isNextScene = isNextScene;

        // should have a check to see
        // if key is collected, then enable portal collider, and spriteMask 
        // portal collider should then check if bossCreature is defeated
        // then 
        // if it is, then instansiate portal beam object, that holds a screnTransition logic.
        // 

        if (player.CompareTag("Player") && !player.isTrigger && GameManager.instance.bossKilled)
        {
            //SceneManager.LoadScene(sceneToLoad);
            Debug.Log("LoadNext scene - test");
            // call gameManager?

            FindObjectOfType<GameManager>().LoadNextScene();
        }

        if (!GameManager.instance.bossKilled)
        {
            Debug.Log("You need to defeat the boss");
        }
    }


}
