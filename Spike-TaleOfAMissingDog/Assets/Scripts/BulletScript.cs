using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector3 mousePos;
    private Camera MainCamera;
    private Rigidbody2D rb;
    public float force;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = MainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        // Vector3 rotation = transform.position - mousePos;

        rb.velocity = new Vector2(direction.x,direction.y).normalized * force;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
