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

