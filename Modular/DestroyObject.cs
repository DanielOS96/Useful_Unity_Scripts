using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject objectToDestroy;

    public GameObject ObjectToDestroy
    {
        get => objectToDestroy;
        set => objectToDestroy = value;
    }

    

    public void DestoryObject()
    {
        Destroy(objectToDestroy);
    }


}
