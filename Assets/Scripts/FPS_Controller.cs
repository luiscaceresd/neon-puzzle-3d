using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPS_Controller : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f, runSpeed = 2.0f, rotationSpeed = 2.0f, k_GroundRayLength = 5.0f, m_JumpPower = 5.0f;
    [SerializeField] private const float groundRayLength = 5f;
    private Rigidbody rb;
    private bool jump;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // where are we moving? 3-DOF
        HandleMovementInput();

        // where are we looking ? 3-DOF
        HandleMouseLook();
    }

    private void HandleMovementInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical) * movementSpeed;
        movement = transform.TransformDirection(movement);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            float currentVerticalVelocity = rb.velocity.y;
            //adjust speed to be running
            float forwardSpeed = movementSpeed * runSpeed;
            //apply spped change to our forward direction, preserving our vertical speed
            Vector3 forwardMovement = transform.forward * forwardSpeed;
            rb.velocity = new Vector3(forwardMovement.x, currentVerticalVelocity, forwardMovement.z);
        }
        else
        {
            rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
        }
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -1.0f * Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up * mouseX * rotationSpeed);
        Camera.main.transform.Rotate(Vector3.right * mouseY * rotationSpeed);
    }
}
