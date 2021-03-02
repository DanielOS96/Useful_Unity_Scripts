using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Some basic MonoBehaviour and proxy methods invoking UnityEvents. 
/// </summary>
public class BasicEvents : MonoBehaviour
{
    [Header("MonoBehaviour Events")]
    public UnityEvent onStart;
    public UnityEvent onUpdate;
    public UnityEvent onFixedUpdate;
    public UnityEvent onEnable;
    public UnityEvent onDisable;
    [Header("Proxy Events")]
    public UnityEvent proxyEvent1;
    public UnityEvent proxyEvent2;
    public UnityEvent proxyEvent3;

    #region Proxy Events 
    public void ProxyEvent1()
    {
        proxyEvent1.Invoke();
    }
    public void ProxyEvent2()
    {
        proxyEvent2.Invoke();
    }
    public void ProxyEvent3()
    {
        proxyEvent3.Invoke();
    }
    #endregion

    #region MonoBehaviour Events

    private void Start()
    {
        onStart.Invoke();
    }

    private void Update()
    {
        onUpdate.Invoke();
    }

    private void FixedUpdate()
    {
        onFixedUpdate.Invoke();
    }

    private void OnEnable()
    {
        onEnable.Invoke();
    }

    private void OnDisable()
    {
        onDisable.Invoke();
    }

    #endregion
}
