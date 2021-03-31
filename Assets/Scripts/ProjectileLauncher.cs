using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchTransform;
    public float impulseMagnitude;
    public Rigidbody projectilePrefab;
    
    public void LaunchProjectile()
    {
        var projectileInstance = Instantiate(projectilePrefab, launchTransform.position, launchTransform.rotation);
        projectileInstance.AddForce(launchTransform.forward.normalized * impulseMagnitude, ForceMode.Impulse);
    }
}