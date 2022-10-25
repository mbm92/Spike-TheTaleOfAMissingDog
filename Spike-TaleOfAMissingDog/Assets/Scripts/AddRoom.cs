using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTemplates templates;

    void Start()
    {
        // get reference for roomTemplates
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();

        // add this room gameObject to the list of rooms in the roomTemplates gameObject.
        templates.rooms.Add(this.gameObject);
    }
}
