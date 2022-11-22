using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("StartRoom Collide with: " + other.tag + ", " + other.name);
        Destroy(other.gameObject);
        // destroy this.spawnPoint GameoBject, so it will not destroy other objects.
        // wait i little bit of time before removing the gameObject
        Destroy(gameObject, 4f);
        Debug.Log("destroy destroyer Obj");
    }
}
