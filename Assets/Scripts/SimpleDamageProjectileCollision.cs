using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDamageProjectileCollision : MonoBehaviour
{
    [SerializeField]
    private int baseDamage = 20;
    
    private void OnCollisionEnter(Collision collision)
    {
        var destructable = collision.gameObject.GetComponent<Destructible>();
        if (destructable != null)
        {
            destructable.HitPoints -= baseDamage;
        }
    }
}
