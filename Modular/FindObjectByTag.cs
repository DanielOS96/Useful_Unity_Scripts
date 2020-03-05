using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class MyGameobjectEvent : UnityEvent<GameObject>{}
/// <summary>
/// Find an object by a tag and return it in an event.
/// </summary>
public class FindObjectByTag : MonoBehaviour
{
    public bool callOnStart;                    //Weather or not to call this on scene start.
    public string tagName;                      //The tag of the object to find.
    public MyGameobjectEvent onObjectFound;     //Called when object has been found. Passes the object.

    // Start is called before the first frame update
    void Start()
    {
        if (callOnStart) FindObj(tagName);
    }

    /// <summary>
    /// Find object and call event.
    /// </summary>
    /// <param name="_tagName">Tag to look for.</param>
    public void FindObj(string _tagName)
    {
        GameObject objFound = GameObject.FindGameObjectWithTag(_tagName);


        if (onObjectFound != null) onObjectFound.Invoke(objFound);
    }

}
