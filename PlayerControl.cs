using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 5f;
    public float rotationSpeed = 150f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = 0f;
        float turn = 0f;

        if (Keyboard.current.wKey.isPressed) move = 1f;
        if (Keyboard.current.sKey.isPressed) move = -1f;

        if (Keyboard.current.aKey.isPressed) turn = 1f;
        if (Keyboard.current.dKey.isPressed) turn = -1f;

        rb.linearVelocity = transform.up * move * speed;
        rb.MoveRotation(rb.rotation + turn * rotationSpeed * Time.deltaTime);
    }
}