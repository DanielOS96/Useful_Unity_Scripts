using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Listen for an ID event matching this classes ID variabel.
/// </summary>
public class IDEventListner : MonoBehaviour
{
    [System.Serializable]
    public class MyGameobjectEvent : UnityEvent<GameObject> { } //Event to pass gameobject referance.

    public int EventIDToListenFor { get => m_eventIDToListenFor; set => m_eventIDToListenFor = value; }

    [SerializeField]
    private int m_eventIDToListenFor = 0;

    [SerializeField]
    private MyGameobjectEvent onIDEventEmitted;






    private void OnEnable()
    {
        SubscribeToEvent();
    }
    private void OnDisable()
    {
        UnsubscribeToEvent();
    }



    /// <summary>
    /// Subscribe to the ID event.
    /// </summary>
    public void SubscribeToEvent()
    {
        IDEventEmitter.emitEventWithID += OnEmitted;
    }
    /// <summary>
    /// Unsubscribe to the ID event.
    /// </summary>
    public void UnsubscribeToEvent()
    {
        IDEventEmitter.emitEventWithID -= OnEmitted;
    }


    //Called on ID event emitted from class IDEventListnable.
    private void OnEmitted(int id, GameObject obj)
    {
        //IF id's match call event.
        if (id == m_eventIDToListenFor)
        {
            onIDEventEmitted.Invoke(obj);
        }
    }
}
