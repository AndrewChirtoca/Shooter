using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent onTimerExpired;

    public void StartTimer(float time)
    {
        StartCoroutine(TimerRoutine(time));
    }
    
    private IEnumerator TimerRoutine(float time)
    {
        yield return new WaitForSeconds(time);
        onTimerExpired.Invoke();
    }
}
