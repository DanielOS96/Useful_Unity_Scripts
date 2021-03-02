using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Set the position, rotation, scale or offset of this transform.
/// </summary>
public class SetTransform : MonoBehaviour
{
   

    public bool Local { get => m_local; set => m_local = value; }

    [SerializeField]
    private Transform m_targetTransform; //Set the target transform.
    [SerializeField]
    private bool m_local;    //Set local or world values.


    private void Awake()
    {
        m_targetTransform = m_targetTransform == null ? m_targetTransform = transform : m_targetTransform;
    }

    #region Offset Position Methods

    /// <summary>
    /// Set the 'X' axis offset position of the transform.
    /// </summary>
    /// <param name="offset">'X' axis offset.</param>
    public void SetOffsetXPosition(float xOffset)
    {
        if (!m_local)
        {
            m_targetTransform.position = new Vector3((m_targetTransform.position.x + xOffset), m_targetTransform.position.y, m_targetTransform.position.z);
        }
        else
        {
            m_targetTransform.localPosition = new Vector3((m_targetTransform.localPosition.x + xOffset), m_targetTransform.localPosition.y, m_targetTransform.localPosition.z);
        }
    }

    /// <summary>
    /// Set the 'Y' axis offset position of the transform.
    /// </summary>
    /// <param name="offset">'Y' axis offset.</param>
    public void SetOffsetYPosition(float yOffset)
    {
        if (!m_local)
        {
            m_targetTransform.position = new Vector3(m_targetTransform.position.x, (m_targetTransform.position.y + yOffset), m_targetTransform.position.z);
        }
        else
        {
            m_targetTransform.localPosition = new Vector3(m_targetTransform.localPosition.x, (m_targetTransform.localPosition.y + yOffset), m_targetTransform.localPosition.z);
        }
    }

    /// <summary>
    /// Set the 'Z' axis offset position of the transform.
    /// </summary>
    /// <param name="offset">'Z' axis offset.</param>
    public void SetOffsetZPosition(float zOffset)
    {
        if (!m_local)
        {
            m_targetTransform.position = new Vector3(m_targetTransform.position.x, m_targetTransform.position.y, (m_targetTransform.position.z + zOffset));
        }
        else
        {
            m_targetTransform.localPosition = new Vector3(m_targetTransform.localPosition.x, m_targetTransform.localPosition.y, (m_targetTransform.localPosition.z + zOffset));
        }
    }
    #endregion

    /// <summary>
    /// Set the position of the transform.
    /// </summary>
    /// <param name="transformPosition">The new position.</param>
    public void SetPosition(Transform transformPosition)
    {
        if (!m_local)
        {
            m_targetTransform.position = transformPosition.position;
        }
        else
        {
            m_targetTransform.localPosition = transformPosition.position;
        }
    }

    /// <summary>
    /// Set the euler roation of the transform.
    /// </summary>
    /// <param name="transformEulerRotation">The new euler rotation.</param>
    public void SetRotationEuler(Transform transformEulerRotation)
    {
        if (!m_local)
        {
            m_targetTransform.eulerAngles = transformEulerRotation.eulerAngles;
        }
        else
        {
            m_targetTransform.localEulerAngles = transformEulerRotation.localEulerAngles;
        }
    }

    /// <summary>
    /// Set the quaternian roation of the transform.
    /// </summary>
    /// <param name="transformQuaternionRotation">The new quaternian rotation.</param>
    public void SetRotationQuaternion(Transform transformQuaternionRotation)
    {
        if (!m_local)
        {
            m_targetTransform.rotation = transformQuaternionRotation.rotation;
        }
        else
        {
            m_targetTransform.localRotation = transformQuaternionRotation.localRotation;
        }
    }

    /// <summary>
    /// Set the scale of the transform.
    /// </summary>
    /// <param name="transformScale">The new scale.</param>
    public void SetScale(Transform transformScale)
    {
        m_targetTransform.localScale = transformScale.localScale;
    }
    
}
