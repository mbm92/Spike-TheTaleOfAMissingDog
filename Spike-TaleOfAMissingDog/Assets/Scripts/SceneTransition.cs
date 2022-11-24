using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class SceneTransition : MonoBehaviour
{

    // need logic to handle which is next scene
    // need logic to generate map of scenes. 


    // public string sceneToLoad;
    // public bool isNextScene = true;

    [SerializeField]
    //public SceneInfo sceneInfo;

    public void OnTriggerEnter2D(Collider2D player)
    {
        //sceneInfo.isNextScene = isNextScene;

        if (player.CompareTag("Player") && !player.isTrigger)
        {
            //SceneManager.LoadScene(sceneToLoad);
            Debug.Log("LoadNext scene - test");
        }


        // what is next room from this on? from this exitPoint? 

        
    }

}
