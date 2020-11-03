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


    //Directly control toggle.
    public void ToggleOff()
    {
        toggle = false;
        toggleOff.Invoke();
    }

    public void ToggleOn()
    {
        toggle = true;
        toggleOn.Invoke();
    }

    public void ConditionalToggleOff()
    {
        if (toggle) ToggleOff();
    }

    public void ConditionalToggleOn()
    {
        if (!toggle) ToggleOn();
    }
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
}
