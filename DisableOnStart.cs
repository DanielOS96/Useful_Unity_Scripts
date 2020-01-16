using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DisableOnStart : MonoBehaviour
{

    public bool disableGameobject = true;
    public UnityEvent onStart;

    // Start is called before the first frame update
    void Start()
    {

        if (disableGameobject)
        {
            gameObject.SetActive(false);
        }

        onStart.Invoke();

    }

}
