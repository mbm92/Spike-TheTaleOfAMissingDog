using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoulCtrl : MonoBehaviour
{
    private Vector3 StartinPos = Vector3.zero;  // where the soul starts on its turn

    public float Speed; // speed of the soul
    public float Sensitivity; // how sensitive a button press is
    private Vector2 MovePos;    // where the heart moves to

    public int MaxX = 2;
    public int MaxY = 2;
    public int MinX = -2;
    public int MinY = -2;
    
    void Start()
    {
        SetSoul();
    }

    public void SetSoul()
    {
        transform.position = StartinPos;
        MovePos = StartinPos;
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * Sensitivity;
        float vertical = Input.GetAxis("Vertical") * Sensitivity;

        MovePos.x += horizontal;
        MovePos.y += vertical;

        MovePos.x = Mathf.Clamp(MovePos.x, MinX, MaxX);
        MovePos.y = Mathf.Clamp(MovePos.y, MinY, MaxY);

        transform.position = Vector2.Lerp(transform.position, MovePos, Speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
