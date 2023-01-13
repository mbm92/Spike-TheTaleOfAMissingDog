using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroScript : MonoBehaviour
{

    private CanvasGroup PressSpace;
    private CanvasGroup Story;
    private CanvasGroup instructions;
    private int State = 1;
    private bool FullyFadeIn = false;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {

        //When state 1 - display story, when state 2 display instructions
        GameManager.instance.outroScene = true;
        PressSpace = GameObject.Find("exit").GetComponent<CanvasGroup>();
        Story = GameObject.Find("story").GetComponent<CanvasGroup>();

        PressSpace.alpha = 0;
        Story.alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (PressSpace.alpha < 1 && State == 1)
        {
            PressSpace.alpha = PressSpace.alpha + Time.deltaTime;
            Story.alpha += Time.deltaTime;
            if (PressSpace.alpha == 1)
            {
                FullyFadeIn = true;
            }
        }
        

        if (Input.GetKeyDown(KeyCode.Space) && FullyFadeIn == true)
        {
            GameManager.instance.LoadMainMenu();
            Destroy(GameObject.FindGameObjectWithTag("GameManager"));  // destroy GameManager
            Destroy(GameObject.FindGameObjectWithTag("GameMusic")); // destory Music instans
        }
    }
}
