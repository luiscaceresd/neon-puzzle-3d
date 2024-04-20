using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private float m_JumpPower = 55.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // get the rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump"))
        {
            // add force in upwards direction
            rb.AddForce(Vector3.up * m_JumpPower, ForceMode.Impulse);
        }
    }
}
