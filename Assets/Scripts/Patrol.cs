using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private Transform pointA, pointB;
    [SerializeField] private float moveSpeed = 5.0f;
    private bool patrolFlag = true; 
    private Rigidbody rb;
    private Vector3 targetPosition;
    private float tolerance = 0.5f;
    //private float tolerance = moveSpeed*Time.fixedDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pointA.position = new Vector3(pointA.position.x, transform.position.y, pointA.position.z);
        pointB.position = new Vector3(pointB.position.x, transform.position.y, pointB.position.z);
        targetPosition = patrolFlag ? pointB.position : pointA.position;
    }

    void FixedUpdate()
    {
        //direction
        Vector3 direction = (targetPosition - transform.position).normalized;

        //move towards target
        rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);

        //figure out angle for look rotation
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, angle, 0);

        //are we at the target?
        if(Vector3.Distance(transform.position, targetPosition) < tolerance)
        {
            patrolFlag = !patrolFlag;
            targetPosition = patrolFlag ? pointB.position : pointA.position;
        }
    }
}
