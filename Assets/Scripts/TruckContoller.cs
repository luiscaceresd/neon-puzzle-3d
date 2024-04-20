using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckContoller : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 5f;
    [SerializeField] private float backwardSpeed = 3f;
    [SerializeField] private float turnSpeed = 50f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveVehicle();
        RotateVehicle();
    }

    private void MoveVehicle()
    {
        float moveInput = Input.GetAxis("Vertical");
        float speed = (moveInput >= 0f) ? forwardSpeed : backwardSpeed;

        // Get the local forward direction of the truck
        Vector3 truckForward = transform.forward;
        truckForward.y = 0f; // Ignore the vertical component

        // Calculate the movement vector based on truck direction
        Vector3 movement = truckForward.normalized * moveInput * speed * Time.deltaTime;

        rb.MovePosition(rb.position + movement);
    }

    private void RotateVehicle()
    {
        float turnInput = Input.GetAxis("Horizontal");
        float turn = turnInput * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }
}

