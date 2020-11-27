using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Set the position, rotation, scale or offset of this transform.
/// </summary>
public class SetTransform : MonoBehaviour
{
   

    public bool Local { get => _local; set => _local = value; }

    [SerializeField]
    private Transform _targetTransform; //Set the target transform.
    [SerializeField]
    private bool _local;    //Set local or world values.


    private void Awake()
    {
        _targetTransform = _targetTransform == null ? _targetTransform = transform : _targetTransform;
    }

    #region Offset Position Methods

    /// <summary>
    /// Set the 'X' axis offset position of the transform.
    /// </summary>
    /// <param name="offset">'X' axis offset.</param>
    public void SetOffsetXPosition(float xOffset)
    {
        if (!_local)
        {
            _targetTransform.position = new Vector3((_targetTransform.position.x + xOffset), _targetTransform.position.y, _targetTransform.position.z);
        }
        else
        {
            _targetTransform.localPosition = new Vector3((_targetTransform.localPosition.x + xOffset), _targetTransform.localPosition.y, _targetTransform.localPosition.z);
        }
    }

    /// <summary>
    /// Set the 'Y' axis offset position of the transform.
    /// </summary>
    /// <param name="offset">'Y' axis offset.</param>
    public void SetOffsetYPosition(float yOffset)
    {
        if (!_local)
        {
            _targetTransform.position = new Vector3(_targetTransform.position.x, (_targetTransform.position.y + yOffset), _targetTransform.position.z);
        }
        else
        {
            _targetTransform.localPosition = new Vector3(_targetTransform.localPosition.x, (_targetTransform.localPosition.y + yOffset), _targetTransform.localPosition.z);
        }
    }

    /// <summary>
    /// Set the 'Z' axis offset position of the transform.
    /// </summary>
    /// <param name="offset">'Z' axis offset.</param>
    public void SetOffsetZPosition(float zOffset)
    {
        if (!_local)
        {
            _targetTransform.position = new Vector3(_targetTransform.position.x, _targetTransform.position.y, (_targetTransform.position.z + zOffset));
        }
        else
        {
            _targetTransform.localPosition = new Vector3(_targetTransform.localPosition.x, _targetTransform.localPosition.y, (_targetTransform.localPosition.z + zOffset));
        }
    }
    #endregion

    /// <summary>
    /// Set the position of the transform.
    /// </summary>
    /// <param name="transformPosition">The new position.</param>
    public void SetPosition(Transform transformPosition)
    {
        if (!_local)
        {
            _targetTransform.position = transformPosition.position;
        }
        else
        {
            _targetTransform.localPosition = transformPosition.position;
        }
    }

    /// <summary>
    /// Set the euler roation of the transform.
    /// </summary>
    /// <param name="transformEulerRotation">The new euler rotation.</param>
    public void SetRotationEuler(Transform transformEulerRotation)
    {
        if (!_local)
        {
            _targetTransform.eulerAngles = transformEulerRotation.eulerAngles;
        }
        else
        {
            _targetTransform.localEulerAngles = transformEulerRotation.localEulerAngles;
        }
    }

    /// <summary>
    /// Set the quaternian roation of the transform.
    /// </summary>
    /// <param name="transformQuaternionRotation">The new quaternian rotation.</param>
    public void SetRotationQuaternion(Transform transformQuaternionRotation)
    {
        if (!_local)
        {
            _targetTransform.rotation = transformQuaternionRotation.rotation;
        }
        else
        {
            _targetTransform.localRotation = transformQuaternionRotation.localRotation;
        }
    }

    /// <summary>
    /// Set the scale of the transform.
    /// </summary>
    /// <param name="transformScale">The new scale.</param>
    public void SetScale(Transform transformScale)
    {
        _targetTransform.localScale = transformScale.localScale;
    }
    
}
