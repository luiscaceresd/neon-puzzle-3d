using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerFire : MonoBehaviour
{
    [SerializeField] private float speed = 20.0f, lifetime = 10.0f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //timer to destroy the lazer
        Destroy(gameObject, lifetime);
        rb = GetComponent<Rigidbody>();
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

        Shoot();
    }

    private void Shoot()
    {
        rb.AddForce(transform.up * speed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WALL"))
        {
            rb.isKinematic = true;
        }
    }
}
