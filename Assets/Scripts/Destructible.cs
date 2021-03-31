using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Destructible : MonoBehaviour
{
    public UnityEvent onDamageReceived;
    public UnityEvent onObjectDestroyed;
    
    [SerializeField]
    private int _hitPoints;

    public int HitPoints
    {
        get
        {
            return _hitPoints;
        }
        set
        {
            if (_hitPoints > value)
            {
                onDamageReceived.Invoke();
            }
            
            _hitPoints = value;
            
            if (_hitPoints < 0)
            {
                onObjectDestroyed.Invoke();
            }
        }
    }
}
