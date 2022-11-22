using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class KeyTrigger : MonoBehaviour
{
    // The list of affected objects by this trigger
    public List<GameObject> TriggeredObjects = new List<GameObject>();

    public static bool KeyCollected = false;    // set a global state for collected key


    #region Member Variables
    /// <summary>
    /// Scaling states to make the object bounce/pulse
    /// </summary>
    private enum SCALEDIRECTION
    {
        UP = 0,
        DOWN = 1,
    }
    private SCALEDIRECTION ScaleDirection;

    /// <summary>
    /// One scale value to retain aspect ratio	
    /// </summary>
    private float ScaleXY = 1.0f;

    /// <summary>
    /// The objects initial scale value 
    /// </summary>
    private float StartingScale = 0.0f;
    #endregion

    void Start()
    {
        StartingScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // change the scale factor the object based on the current state
        if (ScaleDirection == SCALEDIRECTION.UP)
        {
            ScaleXY += 0.5f * Time.deltaTime;
        }
        else if (ScaleDirection == SCALEDIRECTION.DOWN)
        {
            ScaleXY -= 0.5f * Time.deltaTime;
        }

        // limit the scale in both directions
        if (ScaleXY > 1.15f)
        {
            ScaleDirection = SCALEDIRECTION.DOWN;
            ScaleXY = 1.15f;
        }

        if (ScaleXY < 0.85f)
        {
            ScaleDirection = SCALEDIRECTION.UP;
            ScaleXY = 0.85f;
        }

        // apply the scale factor
        transform.localScale = new Vector3(StartingScale * ScaleXY, StartingScale * ScaleXY, transform.localScale.z);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            // toggle this object
            //ToggleObject();

            // toggle each of the objects in the list
            foreach (GameObject obj in TriggeredObjects)
            {
                // check if its a door object, if it is then toggle it using its script

                var child = obj.GetComponentInChildren<DoorWay>();

                if (child)
                {
                    Debug.Log("key Collected");
                    child.ToggleObject();
                    KeyCollected = true;
                    //Debug.Log($"DoorWay Toggled: {child.Toggle}");

                }
            }
            // before destroy set global states that ahve something to do with keyCollected.
            Destroy(gameObject);    // destroy key object, 
        }
    }
}

