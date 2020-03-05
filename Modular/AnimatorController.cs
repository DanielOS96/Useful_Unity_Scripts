using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorController : MonoBehaviour
{
    public Animator anim;

    public string paramName;

    public string ParamaterName
    {
        get => paramName;
        set => paramName = value;
    }


    public void SetBoolParamater(bool value)
    {
        anim.SetBool(paramName, value);
    }


    public void SetTrigger()
    {
        anim.SetTrigger(paramName);
    }

    public void SetInt(int value)
    {
        anim.SetInteger(paramName,value);
    }

    public void SetFloat(float value)
    {
        anim.SetFloat(paramName, value);
    }
}
