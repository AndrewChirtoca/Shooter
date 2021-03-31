using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifetime : MonoBehaviour
{
    public float maxLifetime = 10f;
    
    private void Start()
    {
        Destroy(gameObject, maxLifetime);
    }
}
