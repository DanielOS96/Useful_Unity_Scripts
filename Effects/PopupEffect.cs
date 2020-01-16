using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Preform Popup effect on gameobject.
/// </summary>
public class PopupEffect : MonoBehaviour
{
    [Range(0.1f, 5)]
    public float animationLength = 0.5f;
    [Range(0, 1)]
    public float startSizePercent = 0.1f;
    [Range(0.1f, 1)]
    public float enlargedSizePercent = 0.3f;


    public UnityEvent popupStart;               //Called when the popup starts.
    public UnityEvent popupComplete;            //Called when the popup animation has finished.


    private Vector3[] sizes = new Vector3[5];   //Array of sizes to scale to.
    private Vector3 originalSize;               //Referance to the original size of the gameobject.

    private int currentIndex;                   //The index of the sizes array.




    private void Update()
    {
        if (Input.GetKeyDown("p")) StartPopup();
    }

    private void OnEnable()
    {
        originalSize = gameObject.transform.localScale;
    }


    /// <summary>
    /// Preform the popup animation.
    /// </summary>
    public void StartPopup()
    {
        popupStart.Invoke();


        StopAllCoroutines();
        currentIndex = 1;

        //Setup the sizes that will be scaled to during the animation.
        sizes[0] = originalSize * startSizePercent;
        sizes[1] = originalSize + originalSize * enlargedSizePercent;
        sizes[2] = originalSize - originalSize * 0.1f;
        sizes[3] = originalSize + originalSize * 0.1f;
        sizes[4] = originalSize;

        gameObject.transform.localScale = sizes[0];


        GoToNextSize();
    }

    //Go to the next size in the array.
    private void GoToNextSize()
    {
        if (sizes.Length > currentIndex)
        {
            StartCoroutine(ScaleOverSeconds(sizes[currentIndex], animationLength/sizes.Length));
            currentIndex++;
        }
        else
        {
            currentIndex = 1;
            popupComplete.Invoke();
        }
        
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

        GoToNextSize();
    }

}
