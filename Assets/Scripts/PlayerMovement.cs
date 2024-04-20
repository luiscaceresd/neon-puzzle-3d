using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public float moveSpeed = 5f; // Player movement speed

    private Rigidbody rb;
    private Animator animator; // Reference to the Animator component

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    private void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);
        moveDirection.Normalize(); // Normalize to prevent faster diagonal movement

        // Move the player
        rb.velocity = moveDirection * moveSpeed;

        // Set blend tree parameters for animations
        animator.SetFloat("Speed", moveDirection.magnitude); // Speed parameter for blend tree
        animator.SetFloat("Horizontal", horizontalInput); // Horizontal parameter for blend tree
        animator.SetFloat("Vertical", verticalInput); // Vertical parameter for blend tree
    }
}
