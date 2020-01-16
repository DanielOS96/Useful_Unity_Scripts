using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PopdownEffect : MonoBehaviour
{
    [Range(0.1f, 5)]
    public float animationLength = 0.5f;
    [Range(0, 0.9f)]
    public float endSizePercent = 0.1f;
    [Range(0.1f, 1)]
    public float enlargedSizePercent = 0.3f;

    public bool returnToOriginalSize;


    public UnityEvent popdownStart;               //Called when the popdown animation has started.
    public UnityEvent popdownComplete;            //Called when the popdown animation has finished.


    private Vector3[] sizes = new Vector3[2];   //Array of sizes to scale to.
    private Vector3 originalSize;               //Referance to the original size of the gameobject.

    private Vector3 enlargedSize;
    private Vector3 endSize;



    private void Update()
    {
        if (Input.GetKeyDown("o")) StartPopdown();
    }

    private void OnEnable()
    {
        originalSize = gameObject.transform.localScale;
    }


    /// <summary>
    /// Preform the popup animation.
    /// </summary>
    public void StartPopdown()
    {
        StopAllCoroutines();

        enlargedSize = originalSize + originalSize * enlargedSizePercent;
        endSize = originalSize * endSizePercent;


        gameObject.transform.localScale = originalSize;

        popdownStart.Invoke();

        StartCoroutine(Scale());

    }

    private IEnumerator Scale()
    {
        yield return StartCoroutine(ScaleOverSeconds(enlargedSize,animationLength/2));
        yield return StartCoroutine(ScaleOverSeconds(endSize, animationLength / 2));
        popdownComplete.Invoke();
        if (returnToOriginalSize) gameObject.transform.localScale = originalSize;
    }


    //Scale the gameobject.
    private IEnumerator ScaleOverSeconds(Vector3 endSize, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = gameObject.transform.localScale;

        while (elapsedTime < seconds)
        {
            gameObject.transform.localScale = Vector3.Lerp(startingPos, endSize, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        gameObject.transform.localScale = endSize;

    }
}
