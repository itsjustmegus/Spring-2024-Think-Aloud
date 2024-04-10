using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// include input system from unity engine library
using UnityEngine.InputSystem;
// include namespace for text mesh pro
using TMPro;

public class PlayerController : MonoBehaviour
{
    // player speed variable
    public float speed = 0;
    // text mesh pro variable that holds reference to UI text component of count text gameObject
    public TextMeshProUGUI countText;
    // variable for win text object
    public GameObject winTextObject;

    // reference to rigid body stored in rb variable
    private Rigidbody rb;
    // variable for counting score. Becauase it's private, you can only change initial
    // value in the script
    private int count;
    // x and y values to vector of object
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        // set value of rb to get reference to rigid body component attached to player object
        rb = GetComponent<Rigidbody>();
        // start score at 0
        count = 0;

        // call text method
        SetCountText();
        // deactivate win text object
        winTextObject.SetActive(false);
    }

    // FixedUpdate function to call add force on rigid body stored in rb
    void FixedUpdate()
    {
        // new Vector3 movement variable for adding force to object
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // add force to object multiplied by speed variable
        rb.AddForce(movement * speed);
    }

    // Called by Unity when player first touches a trigger collider
    // It's given a reference to the trigger collider that was touched
    private void OnTriggerEnter(Collider other)
    {
        // If object has the tag "Pickup"
        if (other.gameObject.CompareTag("Pickup"))
        {
            // Deactivate the touched game object
            other.gameObject.SetActive(false);
            // Increment score
            count = count + 1;

            // call text method
            SetCountText();
        }
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

    void SetCountText()
    {
        // display score
        countText.text = "Count: " + count.ToString();

        // if all collectables have been collected
        if(count >= 14)
        {
            // activate win text object
            winTextObject.SetActive(true);
        }
    }
}
