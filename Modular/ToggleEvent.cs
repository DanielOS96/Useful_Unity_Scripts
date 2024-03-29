﻿using System.Collections;
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

    public bool Toggle { get; set; } //This bool will be toggled.


    /// <summary>
    /// Perform the toggle and invoke unity event.
    /// </summary>
    public void PerformToggle()
    {
        Toggle = !Toggle;

        if (Toggle) m_toggleOn.Invoke();
        else m_toggleOff.Invoke();
    }


    /// <summary>
    /// Toggle off and invoke event.
    /// </summary>
    public void ToggleOff()
    {
        Toggle = false;
        m_toggleOff.Invoke();
    }

    /// <summary>
    /// Toggle on and invoke event.
    /// </summary>
    public void ToggleOn()
    {
        Toggle = true;
        m_toggleOn.Invoke();
    }

    /// <summary>
    /// Toggle off if toggle is on and invoke event.
    /// </summary>
    public void ConditionalToggleOff()
    {
        if (Toggle) ToggleOff();
    }

    /// <summary>
    /// Toggle on if toggle is off and invoke event.
    /// </summary>
    public void ConditionalToggleOn()
    {
        if (!Toggle) ToggleOn();
    }

}
