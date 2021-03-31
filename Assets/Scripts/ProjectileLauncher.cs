using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchTransform;
    public float impulseMagnitude;
    public Rigidbody projectilePrefab;

    public bool autoLaunch;
    public float minAutoFrequency = 4f;
    public float maxAutoFrequency = 8f;

    private Coroutine _autoLaunchRoutineInstance;
    
    private void OnEnable()
    {
        if (autoLaunch)
        {
            _autoLaunchRoutineInstance = StartCoroutine(AutoLaunchRoutine());
        }
    }

    private void OnDisable()
    {
        if (_autoLaunchRoutineInstance != null)
        {
            StopCoroutine(AutoLaunchRoutine());
        }
    }

    private IEnumerator AutoLaunchRoutine()
    {
        while (true)
        {
            float randomTime = UnityEngine.Random.Range(minAutoFrequency, maxAutoFrequency);
            yield return new WaitForSeconds(randomTime);
            LaunchProjectile();
        }
    }

    public void LaunchProjectile()
    {
        var projectileInstance = Instantiate(projectilePrefab, launchTransform.position, launchTransform.rotation);
        projectileInstance.AddForce(launchTransform.forward.normalized * impulseMagnitude, ForceMode.Impulse);
    }
}