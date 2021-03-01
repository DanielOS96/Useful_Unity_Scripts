using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// This script will invoke on and off events through a toggle. 
/// </summary>
public class ToggleEvent : MonoBehaviour
{
    public UnityEvent m_toggleOn;   //Called when toggle is true.
    public UnityEvent m_toggleOff;  //Called when toggle is false.

    private bool m_toggle;  //This bool will be toggled.



    /// <summary>
    /// Perform the toggle and invoke unity event.
    /// </summary>
    public void PerformToggle()
    {
        m_toggle = !m_toggle;

        if (m_toggle) m_toggleOn.Invoke();
        else m_toggleOff.Invoke();
    }


    /// <summary>
    /// Toggle off and invoke event.
    /// </summary>
    public void ToggleOff()
    {
        m_toggle = false;
        m_toggleOff.Invoke();
    }

    /// <summary>
    /// Toggle on and invoke event.
    /// </summary>
    public void ToggleOn()
    {
        m_toggle = true;
        m_toggleOn.Invoke();
    }

    /// <summary>
    /// Toggle off if toggle is on and invoke event.
    /// </summary>
    public void ConditionalToggleOff()
    {
        if (m_toggle) ToggleOff();
    }

    /// <summary>
    /// Toggle on if toggle is off and invoke event.
    /// </summary>
    public void ConditionalToggleOn()
    {
        if (!m_toggle) ToggleOn();
    }

}
