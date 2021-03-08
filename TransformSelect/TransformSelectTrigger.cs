using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// When the 'DrawRaycast' script's raycast hits this collider it will 
/// trigger the 'OnRayEnter' and the 'OnRayExit' events respectivly.
/// </summary>
[RequireComponent(typeof(Collider))]
public class TransformSelectTrigger : MonoBehaviour {


    [SerializeField]
    private UnityEvent m_onRayEnter;    //Called when ray has enterd this collider.
    [SerializeField]
    private UnityEvent m_onRayExit;     //Called when ray has exited this collider.


    internal void OnRayEnter()
    {
        m_onRayEnter.Invoke();
        //Debug.Log("Ray Enter: "+gameObject.name);
    }
    internal void OnRayExit()
    {
        m_onRayExit.Invoke();
        //Debug.Log("Ray Exit: " + gameObject.name);
    }

}
