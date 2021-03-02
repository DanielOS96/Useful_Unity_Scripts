using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Check transform against target value. 
/// </summary>
public class CheckTransform : MonoBehaviour
{
    public bool Local { get => m_local; set => m_local = value; }
    public float TargetValue { get => m_targetValue; set => m_targetValue = value; }

    [SerializeField]
    private Transform m_targetTransform; //Set the target transform.
    [SerializeField]
    private float m_targetValue; //The value to reach.
    [SerializeField]
    private bool m_local;    //Set local or world values.
    

    [Header("Check Result Events")]
    [SerializeField]
    private UnityEvent m_transformReachedValue;
    [SerializeField]
    private UnityEvent m_transformAboveValue;
    [SerializeField]
    private UnityEvent m_transformBelowValue;

    /// <summary>
    /// Check if transform position reached target on the 'y' axis and call event.
    /// </summary>
    public void CheckPositionYReached()
    {
        Debug.Log("TargetVal: " + m_targetValue + " TransformPosY: " + m_targetTransform.position.y);

        if (!m_local)
        {
            if (m_targetTransform.position.y == m_targetValue)
            {
                m_transformReachedValue.Invoke();
            }
            else if (m_targetTransform.position.y > m_targetValue)
            {
                m_transformAboveValue.Invoke();
            }
            else if (m_targetTransform.position.y < m_targetValue)
            {
                m_transformBelowValue.Invoke();
            }
        }
        else
        {
            if (m_targetTransform.localPosition.y == m_targetValue)
            {
                m_transformReachedValue.Invoke();
            }
            else if (m_targetTransform.localPosition.y > m_targetValue)
            {
                m_transformAboveValue.Invoke();
            }
            else if (m_targetTransform.localPosition.y < m_targetValue)
            {
                m_transformBelowValue.Invoke();
            }
        }
    }

    //Implement functionality for 'x' axis position check. 
    //Implement functionality for 'y' axis position check. 
    //Implement functionality for 'x' axis  euler check. 
    //Implement functionality for 'y' axis  euler check. 
    //Implement functionality for 'z' axis  euler check. 


}
