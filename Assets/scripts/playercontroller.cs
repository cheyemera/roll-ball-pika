using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playercontroller : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject; 
    
    
    private Rigidbody rb; //creates a variable for rigidbody called rb
    private int count; //easy to understand the role in context
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start() //void creates the function
    {
        rb = GetComponent<Rigidbody>();
        count = 0; //initial count is 0
        //increase count when collect the cube
        SetCountText();
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue) 
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "monch count: " + count.ToString();
        if(count >= 14)
        {
            winTextObject.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY); //f signifies float
        
        rb.AddForce(movement * speed); //need to give this a vector3 variable
        // thus need the movement x & y
    }
    void OnTriggerEnter(Collider other){
        // deactivate the game object rather than destroy it
        // we need to deactivate the correct one
        if(other.gameObject.CompareTag("pickup")) //conditional statement
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
}
