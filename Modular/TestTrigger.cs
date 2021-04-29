using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Trigger event on key down.
/// </summary>
public class TestTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent m_onT = new UnityEvent();
    [SerializeField]
    private UnityEvent m_onY = new UnityEvent();
    [SerializeField]
    private UnityEvent m_onU = new UnityEvent();
    [SerializeField]
    private UnityEvent m_onI = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t")) m_onT.Invoke();
        if (Input.GetKeyDown("y")) m_onY.Invoke();
        if (Input.GetKeyDown("u")) m_onU.Invoke();
        if (Input.GetKeyDown("i")) m_onI.Invoke();
    }


}