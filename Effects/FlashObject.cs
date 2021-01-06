using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Make a list of objects flash via changing material or changing current materials colour.
/// </summary>
public class FlashObject : MonoBehaviour
{
    public GameObject objectToFlash;    //The object to flash the material of.
    public Material flashMaterial;      //The material to replace on the object.

    private bool flashCoroutineActive;  //Wether the flash coroutine is active.

    

    /// <summary>
    /// Flash object to a specified material for 'x' seconds.
    /// </summary>
    /// <param name="timeToFlash">Time flash will take.</param>
    public void FlashMaterial(float timeToFlash)
    {
        if (!flashCoroutineActive) StartCoroutine(FlashMaterialCoroutine(timeToFlash));
    }


    public void RepeatingFlash(float timeToFlash)
    {
        StartCoroutine(RepeatFlash(timeToFlash));
    }

    private IEnumerator RepeatFlash(float timeToFlash)
    {
        while (true)
        {
            if (!flashCoroutineActive) yield return StartCoroutine(FlashMaterialCoroutine(timeToFlash));
            yield return new WaitForSeconds(timeToFlash);
        }
    }



    private IEnumerator FlashMaterialCoroutine(float _flashDuration)
    {
        List<GameObject> gameobjects = new List<GameObject>();
        List<Material> oldMaterials = new List<Material>();
        flashCoroutineActive = true;

        //Add parent gameobject
        Material mat = objectToFlash.GetComponent<Renderer>().material;
        if (mat != null)
        {
            oldMaterials.Add(mat);
            gameobjects.Add(objectToFlash.gameObject);

            //Set parent material.
            objectToFlash.GetComponent<Renderer>().material = flashMaterial;
        }

        //Add children gamobejcts
        foreach (Transform child in objectToFlash.transform)
        {
            Material childMat = child.GetComponent<Renderer>().material;
            if (childMat != null)
            {
                oldMaterials.Add(childMat);
                gameobjects.Add(child.gameObject);

                //Set child material.
                child.GetComponent<Renderer>().material = flashMaterial;
            }
        }


        yield return new WaitForSeconds(_flashDuration);

        // put 'em back
        for (int i = 0; i < oldMaterials.Count; ++i)
        {
            if (gameobjects[i]!=null)gameobjects[i].GetComponent<Renderer>().material = oldMaterials[i];
        }

        flashCoroutineActive = false;
    }



}

