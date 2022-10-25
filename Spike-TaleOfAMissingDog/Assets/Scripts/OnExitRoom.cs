using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;

public class OnExitRoom : MonoBehaviour
{
    public string sceneName;
    public bool isNextScene = true;

    [SerializeField]
    public SceneInfo sceneInfo;

    void OnTriggerEnter2D(Collider2D player)
    {
        sceneInfo.isNextScene = isNextScene;

        SceneManager.LoadScene(sceneName);

        // what is next room from this on? from this exitPoint? 

        Debug.Log("test");
    }


}
