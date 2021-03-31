using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    public enum PathTraversalType
    {
        Once,
        PingPong,
        Loop
    }

    public Rigidbody rigidbody;
    public PathTraversalType traversalType;
    public List<Transform> checkPoints;
    public float randomPointRange;
    public float arrivalThreshold;
    public float speed;
    
    private Vector3 _positionTarget;
    private bool _reverseTraversal;

    private int _targetCheckPointIndex;
    private Action OnTargetCheckPointChanged;
    private int TargetCheckPointIndex
    {
        get
        {
            return _targetCheckPointIndex;
        }
        set
        {
            _targetCheckPointIndex = value;
            OnTargetCheckPointChanged.Invoke();
        }
    }

    private void OnEnable()
    {
        OnTargetCheckPointChanged += RefreshPositionTarget;
        TargetCheckPointIndex = 0;
    }

    private void OnDisable()
    {
        OnTargetCheckPointChanged -= RefreshPositionTarget;
    }

    private void RefreshPositionTarget()
    {
        _positionTarget = checkPoints[_targetCheckPointIndex].position + UnityEngine.Random.insideUnitSphere * randomPointRange;
    }

    private void FixedUpdate()
    {
        float distanceToTarget = Vector3.Distance(rigidbody.position, _positionTarget);
        if (distanceToTarget < arrivalThreshold)
        {
            if (traversalType == PathTraversalType.Once)
            {
                if (TargetCheckPointIndex < checkPoints.Count - 1)
                {
                    TargetCheckPointIndex++;
                }
            }
            else if (traversalType == PathTraversalType.Loop)
            {
                if (TargetCheckPointIndex < checkPoints.Count - 1)
                {
                    TargetCheckPointIndex++;
                }
                else
                {
                    TargetCheckPointIndex = 0;
                }
            }
            else if (traversalType == PathTraversalType.PingPong)
            {
                if (_reverseTraversal)
                {
                    if (TargetCheckPointIndex > 0)
                    {
                        TargetCheckPointIndex--;
                    }
                    else
                    {
                        _reverseTraversal = !_reverseTraversal;
                    }   
                }
                else
                {
                    if (TargetCheckPointIndex < checkPoints.Count - 1)
                    {
                        TargetCheckPointIndex++;
                    }
                    else
                    {
                        _reverseTraversal = !_reverseTraversal;
                    }
                }
            }
        }

        var newPosition = Vector3.MoveTowards(rigidbody.position, _positionTarget, speed * Time.fixedDeltaTime);
        rigidbody.MovePosition(newPosition);
    }
}