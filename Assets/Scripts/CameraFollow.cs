using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform thePLayer;
    private Vector3 offset, cameraNewPosition;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - thePLayer.position;
    }

    void LateUpdate()
    {
        cameraNewPosition = new Vector3(thePLayer.position.x + offset.x, offset.y, thePLayer.position.z + offset.z);
        transform.position = cameraNewPosition;
    }
}
