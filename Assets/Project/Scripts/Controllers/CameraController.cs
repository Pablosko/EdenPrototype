using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smooth;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 cam = transform.position;
        cam = Vector3.Lerp(target.position, cam, smooth * Time.fixedDeltaTime);
        cam.z = -10;
        transform.position = cam;
    }
}
