using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Destroy a set GameObject. 
/// </summary>
public class DestroyObject : MonoBehaviour
{
   

    public GameObject ObjectToDestroy
    {
        get => m_objectToDestroy;
        set => m_objectToDestroy = value;
    }

    [SerializeField]
    private GameObject m_objectToDestroy;   //This gameobject will be destoryed.

    private void Awake()
    {
        //If no gameobject specified use gameobject script is attached to. 
        m_objectToDestroy = m_objectToDestroy == null ? gameObject : m_objectToDestroy;
    }

    /// <summary>
    /// Destroy the set GameObject.
    /// </summary>
    public void PreformDestroy()
    {
        Destroy(m_objectToDestroy);
    }


}
