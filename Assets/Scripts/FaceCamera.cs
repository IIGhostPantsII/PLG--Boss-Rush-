using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    Camera _cameraToLookAt;

    // Start is called before the first frame update
    void Start()
    {
        _cameraToLookAt = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = _cameraToLookAt.transform.position - transform.position;
        lookDirection.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
}
