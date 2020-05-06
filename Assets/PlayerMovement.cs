using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck; //Checks ground of FPS
    public float groundDistance = 0.4f; //radius of sphere
    public LayerMask groundMask; //Control what this object should check for

    bool isGrounded;

    Vector3 velocity; //Velocity for gravity

    // Update is called once per frame
    void Update()
    {
        //Check if grounded (we created a sphere of raidus groundDistance beneath the FPS)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; //better to put -2 than 0
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Arrow direction we want to move based on x and z movement, and the way the player is facing
        Vector3 move = transform.right * x + transform.forward * z; //transform.right takes direction player is facing and moves to right

        controller.Move(move * speed * Time.deltaTime);

        //Jump
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
