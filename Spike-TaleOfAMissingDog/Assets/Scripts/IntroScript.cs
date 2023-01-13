using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
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
        State = 1;
        PressSpace = GameObject.Find("space").GetComponent<CanvasGroup>();
        Story = GameObject.Find("story").GetComponent<CanvasGroup>();
        instructions = GameObject.Find("instructions").GetComponent<CanvasGroup>();

        PressSpace.alpha = 0;
        Story.alpha = 0;
        instructions.alpha = 0;

        
    }

    // Update is called once per frame
    void Update()
    {
        if  (PressSpace.alpha <1 && State == 1){
            PressSpace.alpha = PressSpace.alpha + Time.deltaTime;
            Story.alpha += Time.deltaTime;
            if (PressSpace.alpha == 1){
                FullyFadeIn = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && FullyFadeIn == true && State ==1){
            FullyFadeIn = false;
            State = 2;
        }

        if (Story.alpha >=0  && State ==2){
            Story.alpha -= Time.deltaTime;
            if (Story.alpha == 0){
                FullyFadeIn = false;
            }
        }
        if (FullyFadeIn== false && State ==2){
            instructions.alpha += Time.deltaTime;
            if (instructions.alpha ==1){
                FullyFadeIn = true;
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && State ==2 && FullyFadeIn == true){
            SceneManager.LoadScene(sceneName);
        }
    }
}
