using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// inspiration from https://www.youtube.com/watch?v=LNLVOjbrQj4&list=PLTzVrU_BaEcglpVq4NkELDWG8m0uFYOlW&index=29&ab_channel=Brackeys


public class PlayerMovementV2 : MonoBehaviour
{
    
    public float moveSpeed = 5f;

    public Rigidbody2D rigidbody;

    public Camera cam;

    private Vector2 moveDirection;
    private Vector2 mousePos;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

        // find input for mouse
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        
        Move();
        RotatePlayer();

    }

    void ProcessInputs()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");

        // handle diagonal movementspeed to not be faster then one-directional.
        moveDirection.Normalize();
    }

    void Move()
    {
        rigidbody.MovePosition(rigidbody.position + moveDirection * moveSpeed * Time.fixedDeltaTime);

        // rigidbody.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    // rotate player to look toward mouse position
    void RotatePlayer()
    {
        Vector2 lookDir = mousePos - rigidbody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rigidbody.rotation = angle;
    }
}
