using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckTransform : MonoBehaviour
{
    public bool Local { get => _local; set => _local = value; }
    public float TargetValue { get => _targetValue; set => _targetValue = value; }

    [SerializeField]
    private Transform _targetTransform; //Set the target transform.
    [SerializeField]
    private float _targetValue; //The value to reach.
    [SerializeField]
    private bool _local;    //Set local or world values.
    

    [Header("Check Result Events")]
    [SerializeField]
    private UnityEvent _transformReachedValue;
    [SerializeField]
    private UnityEvent _transformAboveValue;
    [SerializeField]
    private UnityEvent _transformBelowValue;

    public void CheckPositionYReached()
    {
        Debug.Log("TargetVal: " + _targetValue + " TransformPosY: " + _targetTransform.position.y);

        if (!_local)
        {
            if (_targetTransform.position.y == _targetValue)
            {
                _transformReachedValue.Invoke();
            }
            else if (_targetTransform.position.y > _targetValue)
            {
                _transformAboveValue.Invoke();
            }
            else if (_targetTransform.position.y < _targetValue)
            {
                _transformBelowValue.Invoke();
            }
        }
        else
        {
            if (_targetTransform.localPosition.y == _targetValue)
            {
                _transformReachedValue.Invoke();
            }
            else if (_targetTransform.localPosition.y > _targetValue)
            {
                _transformAboveValue.Invoke();
            }
            else if (_targetTransform.localPosition.y < _targetValue)
            {
                _transformBelowValue.Invoke();
            }
        }
    }



}
