using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TestTrigger : MonoBehaviour
{

    public UnityEvent onT;
    public UnityEvent onY;
    public UnityEvent onU;
    public UnityEvent onI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t")) onT.Invoke();
        if (Input.GetKeyDown("y")) onYInvoke();
        if (Input.GetKeyDown("u")) onU.Invoke();
        if (Input.GetKeyDown("i")) onI.Invoke();
    }


}
