using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunTrigger : MonoBehaviour
{
    public UnityEvent onTriggerPulled;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            onTriggerPulled.Invoke();
        }
    }
}
