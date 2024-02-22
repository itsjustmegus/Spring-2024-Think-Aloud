using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// include input system from unity engine library
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // player speed variable
    public float speed = 0;

    // reference to rigid body stored in rb variable
    private Rigidbody rb;
    // x and y values to vector of object
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        // set value of rb to get reference to rigid body component attached to player object
        rb = GetComponent<Rigidbody>();
    }

    // OnMove function with variable passed in containing x and y value information of object
    void OnMove(InputValue movementValue)
    {
        // take vector2 data from movementValue and stores it in movementVector variable
        Vector2 movementVector = movementValue.Get<Vector2>();

        // set movementVector values to x and y values of object
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate function to call add force on rigid body stored in rb
    void FixedUpdate()
    {
        // new Vector3 movement variable for adding force to object
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // add force to object multiplied by speed variable
        rb.AddForce(movement * speed);
    }
}
