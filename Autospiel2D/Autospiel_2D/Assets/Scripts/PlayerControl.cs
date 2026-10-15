using UnityEngine;
using UnityEngine.InputSystem;
using Math = System.Math;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D rb;

    public float speed = 30f;
    public float rotationSpeed = 1000f;
    public float turn_correc_movement = 40f;
    public float acceleration_val = 4f;
    public float resistance = 0.99f;
    public float max_rotate_speed = 10f;


    private float move = 0f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        float accel = 0f;
        float turn = 0f;
        
        // if (Keyboard.current.wKey.isPressed) move = 1f;
        // if (Keyboard.current.sKey.isPressed) move = -0.4f;
        // if (Keyboard.current.sKey.isPressed && Keyboard.current.wKey.isPressed) move = 0f;

        if (Keyboard.current.wKey.isPressed) accel = acceleration_val;
        if (Keyboard.current.sKey.isPressed) accel = -0.4f * acceleration_val;
        if (Keyboard.current.sKey.isPressed && Keyboard.current.wKey.isPressed) accel = 0f;

        if (Keyboard.current.aKey.isPressed) turn = 1f;
        if (Keyboard.current.dKey.isPressed) turn = -1f;
        if (Keyboard.current.dKey.isPressed && Keyboard.current.aKey.isPressed) turn = 0f;


        move = move +    accel * Time.deltaTime;
        move = move * resistance;

        if (move > 1f)
        {
            move = 1f;
        }
        if (move < -0.4f)
        {
            move = -0.4f;
        }

        rb.linearVelocity = transform.up     * move * speed;

        
        if (move != 0f && Math.Abs(move) > 0.4f)
        {

            float rotate = (turn * rotationSpeed * Time.deltaTime *turn_correc_movement *0.4f   )/(move*speed);
            if (rotate > max_rotate_speed)
            {
                rotate = max_rotate_speed;
            }
            if (rotate < -max_rotate_speed)
            {
                rotate = -max_rotate_speed;
            }


            rb.MoveRotation(rb.rotation + rotate);    
        }
        else if (move != 0f && Math.Abs(move) <= 0.4f)
        {

            float rotate = (turn * rotationSpeed * Time.deltaTime *move*speed * (25f/4f) * (1f/turn_correc_movement) );
            if (rotate > max_rotate_speed)
            {
                rotate = max_rotate_speed;
            }
            if (rotate < -max_rotate_speed)
            {
                rotate = -max_rotate_speed;
            }


            rb.MoveRotation(rb.rotation + rotate);    
        }
        
    }
}
