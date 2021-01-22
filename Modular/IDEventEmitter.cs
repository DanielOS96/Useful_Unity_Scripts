using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Send out delegate with ID variable.
/// </summary>
public class IDEventEmitter : MonoBehaviour
{

    public delegate void EmitEvent(int id);

    public static EmitEvent emitEventWithID;

    public int EventID { get => m_eventID; set => m_eventID = value; }

    [SerializeField]
    private int m_eventID = 0;


    /// <summary>
    /// Invoke the delegate with the ID variable.
    /// </summary>
    public void EmitTheEventWithID()
    {
        if (emitEventWithID != null)
            emitEventWithID.Invoke(m_eventID);
    }
}
