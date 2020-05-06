using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //Controls speed of mouse
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Hide and lock cursor to center of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //mouseX is movement from side to side
        //Mouse X is preprogrammed in unity that checks for x axis changes.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //Time.deltaTime is the time that has passed since the last time the Update fucntion was called. Solve issues of different frame rates
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //That way we dont over-rotate

        transform.localRotation = Quaternion.Euler(xRotation, 0F, 0F);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
