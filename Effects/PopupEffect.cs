using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Perform popup effect on a gameobject.
/// <para>Gameobject will be scaled from a small size to a larger size then back down to its original size.</para>
/// </summary>
public class PopupEffect : MonoBehaviour
{
    [Range(0.1f, 5)]
    [SerializeField]
    private float m_animationLength = 0.5f;     //The length the resize will take to complete in seconds.
    [Range(0, 1)]
    [SerializeField]
    private float m_startSizePercent = 0.1f;    //The percent scale the item will begin the resize from.
    [Range(0.1f, 1)]
    [SerializeField]
    private float m_enlargedSizePercent = 0.3f; //The percent scale the item will enlarge to before going to original size.


    [SerializeField]
    private UnityEvent m_popupStart;               //Called when the popup starts.
    [SerializeField]
    private UnityEvent m_popupComplete;            //Called when the popup animation has finished.


    private Vector3[] m_sizes = new Vector3[5];   //Array of sizes to scale to.
    private Vector3 m_originalSize;               //Referance to the original size of the gameobject.

    private int m_currentIndex;                   //The index of the sizes array.




    private void Update()
    {
        if (Input.GetKeyDown("p")) StartPopup();
    }

    private void OnEnable()
    {
        m_originalSize = gameObject.transform.localScale;
    }


    /// <summary>
    /// Perform the popup animation.
    /// </summary>
    public void StartPopup()
    {
        m_popupStart.Invoke();


        StopAllCoroutines();
        m_currentIndex = 1;

        //Setup the sizes that will be scaled to during the animation.
        m_sizes[0] = m_originalSize * m_startSizePercent;
        m_sizes[1] = m_originalSize + m_originalSize * m_enlargedSizePercent;
        m_sizes[2] = m_originalSize - m_originalSize * 0.1f;
        m_sizes[3] = m_originalSize + m_originalSize * 0.1f;
        m_sizes[4] = m_originalSize;

        gameObject.transform.localScale = m_sizes[0];


        GoToNextSize();
    }

    //Go to the next size in the array.
    private void GoToNextSize()
    {
        if (m_sizes.Length > m_currentIndex)
        {
            StartCoroutine(ScaleOverSeconds(m_sizes[m_currentIndex], m_animationLength/m_sizes.Length));
            m_currentIndex++;
        }
        else
        {
            m_currentIndex = 1;
            m_popupComplete.Invoke();
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
