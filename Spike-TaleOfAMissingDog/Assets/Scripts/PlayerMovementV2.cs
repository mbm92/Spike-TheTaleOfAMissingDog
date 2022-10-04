using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// inspiration from https://www.youtube.com/watch?v=LNLVOjbrQj4&list=PLTzVrU_BaEcglpVq4NkELDWG8m0uFYOlW&index=29&ab_channel=Brackeys


public class PlayerMovementV2 : MonoBehaviour
{
    
    public float moveSpeed = 5f;

    public Rigidbody2D rigidbody;

    public Camera cam;

    private Vector2 movement;
    private Vector2 mousePos;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // find input for mouse
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);

        RotatePlayer();

    }

    // rotate player to look toward mouse position
    void RotatePlayer()
    {
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
    }
}
