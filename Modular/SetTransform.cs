using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Set the position, rotation, scale or offset of this transform.
/// <para>Contains methods for re-parenting, offsetting and manually setting based off defined values.</para>
/// </summary>
public class SetTransform : MonoBehaviour
{


    [SerializeField]
    private Transform m_transformToModify; //Set the target transform.
    [SerializeField]
    private Transform m_transformToCopy; //Set the target transform to this transforms position.
    [SerializeField]
    private bool m_local;    //Set local or world values.
    [SerializeField]
    Vector3 m_manualPosition;   //The used when setting position manually
    [SerializeField]
    Vector3 m_manualRotationEuler;   //The used when setting euler rotation manually
    [SerializeField]
    Vector3 m_offsetPosition;   //The values to offset the transform by.

    private Transform m_originalParent; //The original parent of the transform to modify.

    //Properties.
    public Transform TransformToModify { get => m_transformToModify; set => m_transformToModify = value; }
    public GameObject GameObjectToModify { get => m_transformToModify.gameObject; set => m_transformToModify = value.transform; }
    public Transform TransformToCopy { get => m_transformToCopy; set => m_transformToCopy = value; }
    public GameObject GameObjectToCopy { get => m_transformToCopy.gameObject; set => m_transformToCopy = value.transform; }

    public bool Local { get => m_local; set => m_local = value; }


    private void Awake()
    {
        //Set up the transform to modify variable to this transform on awake if nothing set.
        m_transformToModify = m_transformToModify == null ? m_transformToModify = transform : m_transformToModify;
    }


    #region Offset Position Methods
    /// <summary>
    /// Offset the position of the transform to modify to the values of the OffsetPosition Vector 3 variable.
    /// </summary>
    public void SetOffsetPosition()
    {
        SetOffsetXPosition(m_offsetPosition.x);
        SetOffsetYPosition(m_offsetPosition.y);
        SetOffsetZPosition(m_offsetPosition.z);
    }

    /// <summary>
    /// Set the 'X' axis offset position of the transform.
    /// </summary>
    /// <param name="offset">'X' axis offset.</param>
    public void SetOffsetXPosition(float xOffset)
    {
        if (!m_local)
        {
            m_transformToModify.position = new Vector3((m_transformToModify.position.x + xOffset), m_transformToModify.position.y, m_transformToModify.position.z);
        }
        else
        {
            m_transformToModify.localPosition = new Vector3((m_transformToModify.localPosition.x + xOffset), m_transformToModify.localPosition.y, m_transformToModify.localPosition.z);
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
            m_transformToModify.position = new Vector3(m_transformToModify.position.x, (m_transformToModify.position.y + yOffset), m_transformToModify.position.z);
        }
        else
        {
            m_transformToModify.localPosition = new Vector3(m_transformToModify.localPosition.x, (m_transformToModify.localPosition.y + yOffset), m_transformToModify.localPosition.z);
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
            m_transformToModify.position = new Vector3(m_transformToModify.position.x, m_transformToModify.position.y, (m_transformToModify.position.z + zOffset));
        }
        else
        {
            m_transformToModify.localPosition = new Vector3(m_transformToModify.localPosition.x, m_transformToModify.localPosition.y, (m_transformToModify.localPosition.z + zOffset));
        }
    }
    #endregion


    #region Re-Parenting Methods
    /// <summary>
    /// Set the parent of the transform to modify to the transform to copy.
    /// </summary>
    public void ParentTransformToModifyToTransformToCopy()
    {
        m_originalParent = m_transformToModify.parent;//Store referance to original parent.
        m_transformToModify.parent = m_transformToCopy;//Set the new parent.
    }
    /// <summary>
    /// Set the parent of the transform to modify to its original parent.
    /// </summary>
    public void DeparentTransformToModifyFromTransformToCopy()
    {
        ReparentTransformToModify(m_originalParent);
    }
    /// <summary>
    /// Set the parent of the transform to modify to a new parent.
    /// </summary>
    public void ReparentTransformToModify(Transform newParent)
    {
        m_transformToModify.parent = newParent;
    }
    #endregion


    #region Manual Set Transform Methods
    /// <summary>
    /// Manually set the euler position of the transform to modify to the value of the ManualPosition Vector3 variable.
    /// </summary>
    public void ManuallySetPosition()
    {
        ManuallySetPosition(m_manualPosition);
    }
    /// <summary>
    /// Manually set the position of the transform to modify to a given Vector 3.
    /// </summary>
    /// <param name="newRotation">The new eular angle.</param>
    public void ManuallySetPosition(Vector3 newPosition)
    {
        if (!m_local)
        {
            m_transformToModify.position = newPosition;
        }
        else
        {
            m_transformToModify.localPosition = newPosition;
        }
    }


    /// <summary>
    /// Manually set the euler rotation of the transform to modify to the value of the ManualRotationEuler Vector3 variable.
    /// </summary>
    public void ManuallySetRotationEuler()
    {
        ManuallySetRotationEuler(m_manualRotationEuler);
    }
    /// <summary>
    /// Manually set the euler rotation of the transform to modify to a given Vector 3.
    /// </summary>
    /// <param name="newRotation">The new eular angle.</param>
    public void ManuallySetRotationEuler(Vector3 newRotation)
    {
        if (!m_local)
        {
            m_transformToModify.eulerAngles = newRotation;
        }
        else
        {
            m_transformToModify.localEulerAngles = newRotation;
        }
    }
    #endregion


    #region Set Transform Methods
    /// <summary>
    /// Set the position of the transform to the transform to copy transform variable..
    /// </summary>
    public void SetPosition()
    {
        SetPosition(m_transformToCopy);
    }
    /// <summary>
    /// Set the position of the transform.
    /// </summary>
    /// <param name="transformPosition">The new position.</param>
    public void SetPosition(Transform transformPosition)
    {
        if (!m_local)
        {
            m_transformToModify.position = transformPosition.position;
        }
        else
        {
            m_transformToModify.localPosition = transformPosition.localPosition;
        }
    }

    /// <summary>
    /// Set the euler roation of the transform to the transform to copy transform variable.
    /// </summary>
    public void SetRotationEuler()
    {
        SetRotationEuler(m_transformToCopy);
    }
    /// <summary>
    /// Set the euler roation of the transform.
    /// </summary>
    /// <param name="transformEulerRotation">The new euler rotation.</param>
    public void SetRotationEuler(Transform transformEulerRotation)
    {
        if (!m_local)
        {
            m_transformToModify.eulerAngles = transformEulerRotation.eulerAngles;
        }
        else
        {
            m_transformToModify.localEulerAngles = transformEulerRotation.localEulerAngles;
        }
    }

    /// <summary>
    /// Set the quaternian roation of the transform to the transform to copy transform variable.
    /// </summary>
    public void SetRotationQuaternion()
    {
        SetRotationQuaternion(m_transformToCopy);
    }
    /// <summary>
    /// Set the quaternian roation of the transform.
    /// </summary>
    /// <param name="transformQuaternionRotation">The new quaternian rotation.</param>
    public void SetRotationQuaternion(Transform transformQuaternionRotation)
    {
        if (!m_local)
        {
            m_transformToModify.rotation = transformQuaternionRotation.rotation;
        }
        else
        {
            m_transformToModify.localRotation = transformQuaternionRotation.localRotation;
        }
    }


    /// <summary>
    /// Set the scale of the transform to the transform to copy transform variable.
    /// </summary>
    public void SetScale()
    {
        SetScale(m_transformToCopy);
    }
    /// <summary>
    /// Set the scale of the transform.
    /// </summary>
    /// <param name="transformScale">The new scale.</param>
    public void SetScale(Transform transformScale)
    {
        m_transformToModify.localScale = transformScale.localScale;
    }
    #endregion

}
