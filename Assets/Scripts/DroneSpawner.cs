using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject dronePrefab;
    public int maxDronesCount;
    public float spawnTime;
    public Transform spawnTransform;
    public List<Transform> spawnerPath;

    private int _currentDronesCount;
    
    private void OnEnable()
    {
        SpawnRecursive();
    }

    private void SpawnRecursive()
    {
        if (enabled)
        {
            if (_currentDronesCount < maxDronesCount)
            {
                var droneInstance = Instantiate(dronePrefab, spawnTransform.position, spawnTransform.rotation);
                droneInstance.GetComponent<PathFollower>().checkPoints = spawnerPath;
                droneInstance.SetActive(true);
                _currentDronesCount++;
            }
            Invoke(nameof(SpawnRecursive), spawnTime);
        }
    }
}