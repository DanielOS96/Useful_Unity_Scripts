using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
/// <summary>
/// Perform the popdown effect on a gameobject.
/// </summary>
public class PopdownEffect : MonoBehaviour
{
    [Range(0.1f, 5)]
    [SerializeField]
    private float m_animationLength = 0.5f;     //The length the resize will take to complete in seconds.
    [Range(0, 0.9f)]
    [SerializeField]
    private float m_endSizePercent = 0.1f;      //The percent scale the item will begin the resize from.
    [Range(0.1f, 1)]
    [SerializeField]
    private float m_enlargedSizePercent = 0.3f;     //The percent scale the item will enlarge to before going to original size.

    [SerializeField]
    private bool m_returnToOriginalSize;            //Return to original size after popdown animation complete.

    [SerializeField]
    private UnityEvent m_popdownStart;               //Called when the popdown animation has started.
    [SerializeField]
    private UnityEvent m_popdownComplete;            //Called when the popdown animation has finished.


    private Vector3 m_originalSize;               //Referance to the original size of the gameobject.

    private Vector3 m_enlargedSize;
    private Vector3 m_endSize;



    private void Update()
    {
        if (Input.GetKeyDown("o")) StartPopdown();
    }

    private void OnEnable()
    {
        m_originalSize = gameObject.transform.localScale;
    }


    /// <summary>
    /// Perform the popdown animation.
    /// </summary>
    public void StartPopdown()
    {
        StopAllCoroutines();

        m_enlargedSize = m_originalSize + m_originalSize * m_enlargedSizePercent;
        m_endSize = m_originalSize * m_endSizePercent;


        gameObject.transform.localScale = m_originalSize;

        m_popdownStart.Invoke();

        StartCoroutine(Scale());

    }

    //The paceing of the movements.
    private IEnumerator Scale()
    {
        yield return StartCoroutine(ScaleOverSeconds(m_enlargedSize,m_animationLength/2));
        yield return StartCoroutine(ScaleOverSeconds(m_endSize, m_animationLength / 2));
        m_popdownComplete.Invoke();
        if (m_returnToOriginalSize) gameObject.transform.localScale = m_originalSize;
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
