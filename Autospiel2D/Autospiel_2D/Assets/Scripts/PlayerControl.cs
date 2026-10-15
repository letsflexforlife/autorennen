using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 5f;
    public float rotationSpeed = 300f;
    public float turn_correc_movement = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = 0f;
        float turn = 0f;

        if (Keyboard.current.wKey.isPressed) move = 1f;
        if (Keyboard.current.sKey.isPressed) move = -0.4f;
        if (Keyboard.current.sKey.isPressed && Keyboard.current.wKey.isPressed) move = 0f;

        if (Keyboard.current.aKey.isPressed) turn = 1f;
        if (Keyboard.current.dKey.isPressed) turn = -1f;
        if (Keyboard.current.dKey.isPressed && Keyboard.current.aKey.isPressed) turn = 0f;

        rb.linearVelocity = transform.up * move * speed;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            rb.MoveRotation(rb.rotation + (turn * rotationSpeed * Time.deltaTime *turn_correc_movement)/(move*speed));    
        }
        
    }
}