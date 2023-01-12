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
        
        collider = gameObject.GetComponent<Collider2D>();
        
        _mask = Mask;

        if (!doorOpened)
        {
            Mask.enabled = false;   // turn off runes
            
            collider.enabled = false;
            
        }
        else if(doorOpened)
        {
            Mask.enabled = true;    // turns on runes
            collider.enabled = true;
            
        }
    }

    public void ToggleObject()
    {
       
    
        _mask.enabled = true;
        collider.enabled = true;
        //collider.enabled = !collider.enabled; // if i want a toggle effect

        // should have a check to see
        // if key is collected, then enable portal collider, and spriteMask 
        // portal collider should then check if bossCreature is defeated
        // then 
        // if it is, then instansiate portal beam object, that holds a screnTransition logic.
        // 

        
        if (collider.isActiveAndEnabled)
        {
            
            doorOpened = true;
        }
        else
        {
           
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
            
            // call gameManager?

            FindObjectOfType<GameManager>().LoadNextScene();
        }

        if (!GameManager.instance.bossKilled)
        {
            Debug.Log("You need to defeat the boss");
        }
    }


}
