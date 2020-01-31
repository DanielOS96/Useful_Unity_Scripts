using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// This script is to be placed on a gamobejct with a collider.
/// When the 'DrawRaycast' script's raycast hits a gameobject with a collider
/// and this script it will trigger the 'OnHoverOn' and the 'OnHoverOff' events respectivly.
/// </summary>
public class TransformSelectTrigger : MonoBehaviour {

    public delegate void Look();
    public event Look OnHoverOn;
    public event Look OnHoverOff;

    public UnityEvent OnGazed;
    public UnityEvent OnUngazed;


    public void OnRayEnter()
    {
        if (OnHoverOn != null) OnHoverOn();
        OnGazed.Invoke();
        //Debug.Log("Looking");
    }
    public void OnRayExit()
    {
        if (OnHoverOff != null) OnHoverOff();
        OnUngazed.Invoke();
        //Debug.Log("Not Looking");
    }

}
