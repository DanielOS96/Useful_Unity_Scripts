using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Make a gameobject flash bu changing it and all its childrens materials then return the original materials.
/// </summary>
public class FlashObject : MonoBehaviour
{
    [SerializeField]
    private GameObject m_objectToFlash;    //The object to flash the material of.
    [SerializeField]
    private Material m_flashMaterial;      //The material to replace on the object.

    private bool m_flashCoroutineActive;  //Wether the flash coroutine is active.

    

    /// <summary>
    /// Flash object to a specified material for 'x' seconds.
    /// </summary>
    /// <param name="timeToFlash">Time flash will take.</param>
    public void FlashMaterial(float timeToFlash)
    {
        if (!m_flashCoroutineActive) StartCoroutine(FlashMaterialCoroutine(timeToFlash));
    }

    /// <summary>
    /// Repeat the flashing effect.
    /// </summary>
    /// <param name="timeToFlash">Time the flash will take.</param>
    public void RepeatingFlash(float timeToFlash)
    {
        StartCoroutine(RepeatFlash(timeToFlash));
    }

    //Invoke the flash repeditavly.
    private IEnumerator RepeatFlash(float timeToFlash)
    {
        while (true)
        {
            if (!m_flashCoroutineActive) yield return StartCoroutine(FlashMaterialCoroutine(timeToFlash));
            yield return new WaitForSeconds(timeToFlash);
        }
    }


    //Flash the object to the specified material then back.
    private IEnumerator FlashMaterialCoroutine(float _flashDuration)
    {
        List<GameObject> gameobjects = new List<GameObject>();
        List<Material> oldMaterials = new List<Material>();
        m_flashCoroutineActive = true;

        //Add parent gameobject
        Material mat = m_objectToFlash.GetComponent<Renderer>().material;
        if (mat != null)
        {
            oldMaterials.Add(mat);
            gameobjects.Add(m_objectToFlash.gameObject);

            //Set parent material.
            m_objectToFlash.GetComponent<Renderer>().material = m_flashMaterial;
        }

        //Add children gamobejcts
        foreach (Transform child in m_objectToFlash.transform)
        {
            Material childMat = child.GetComponent<Renderer>().material;
            if (childMat != null)
            {
                oldMaterials.Add(childMat);
                gameobjects.Add(child.gameObject);

                //Set child material.
                child.GetComponent<Renderer>().material = m_flashMaterial;
            }
        }


        yield return new WaitForSeconds(_flashDuration);

        // put 'em back
        for (int i = 0; i < oldMaterials.Count; ++i)
        {
            if (gameobjects[i]!=null)gameobjects[i].GetComponent<Renderer>().material = oldMaterials[i];
        }

        m_flashCoroutineActive = false;
    }



}

