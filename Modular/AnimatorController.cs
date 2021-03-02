using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Set an animator parameter.
/// </summary>
public class AnimatorController : MonoBehaviour
{
    

    public string ParamaterName
    {
        get => m_paramName;
        set => m_paramName = value;
    }

    [SerializeField]
    private Animator m_animator;

    [SerializeField]
    private string m_paramName;


    /// <summary>
    /// Set a bool parameter in the animator.
    /// </summary>
    /// <param name="value">The value to set the animator bool.</param>
    public void SetBoolParamater(bool value)
    {
        m_animator.SetBool(m_paramName, value);
    }

    /// <summary>
    /// Set a trigger parameter in the animator.
    /// </summary>
    public void SetTrigger()
    {
        m_animator.SetTrigger(m_paramName);
    }

    /// <summary>
    /// Set an int parameter in the animator.
    /// </summary>
    /// <param name="value">The value to set the animator int.</param>
    public void SetInt(int value)
    {
        m_animator.SetInteger(m_paramName,value);
    }

    /// <summary>
    /// Set a float parameter in the animator.
    /// </summary>
    /// <param name="value">The value to set the animator float.</param>
    public void SetFloat(float value)
    {
        m_animator.SetFloat(m_paramName, value);
    }
}
