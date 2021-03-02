using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Find an object then pass object referance in a unity event.
/// </summary>
public class FindObject : MonoBehaviour
{

    [System.Serializable]
    private class MyGameObjectEvent : UnityEvent<GameObject> { } //Event to pass gameobject referance.


    public string ObjectTag { get => m_objectTag; set => m_objectTag = value; } //Property for get/setting tag string.

    [SerializeField]
    private string m_objectTag; //Tag string to find object by.
    [SerializeField]
    private MyGameObjectEvent m_onObjectFound;  //Event called on object found.



    /// <summary>
    /// Find the object by tag string.
    /// </summary>
    public void FindObjectByTag()
    {
        if (m_objectTag == null) return;

        GameObject[] foundObjects = GameObject.FindGameObjectsWithTag(m_objectTag);

        foreach (GameObject foundObject in foundObjects)
        {
            m_onObjectFound.Invoke(foundObject);
        }

    }

}
