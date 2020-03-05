using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleEvent : MonoBehaviour
{
    public UnityEvent toggleOn;
    public UnityEvent toggleOff;

    private bool toggle;




    public void PreformToggle()
    {
        toggle = !toggle;

        if (toggle) toggleOn.Invoke();
        else toggleOff.Invoke();
    }
}
