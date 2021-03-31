using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyLookAtCamera : MonoBehaviour
{
    public Rigidbody rigidbody;
    private static Transform mainCamTransform;

    private void OnEnable()
    {
        if (mainCamTransform == null)
        {
            mainCamTransform = Camera.main.transform;
        }
    }

    private void FixedUpdate()
    {
        Vector3 lookAtDirection = mainCamTransform.position - rigidbody.position;
        var lookRotation = Quaternion.LookRotation(lookAtDirection);
        rigidbody.MoveRotation(lookRotation);
    }
}
