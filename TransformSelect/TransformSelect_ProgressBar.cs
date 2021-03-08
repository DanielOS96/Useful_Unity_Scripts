using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This is a decorator class for TransformSelect script.
/// This script will show a progress bar to indicate the 
/// transfroms current progress to its target.
/// </summary>
public class TransformSelect_ProgressBar : MonoBehaviour {

    [SerializeField]
    private TransformSelect m_scriptInstance;  //Referance to the transform select script instance.

    [Header("Progress Bar Variables")]
    [SerializeField]
    private bool m_hideCanvasWhenInactive;      //Show the progress bar canvas when the transform select is not active.
    [SerializeField]
    private Image m_progressBar;               //Referance to the progress bar.

    private GameObject m_canvasParent;          //Referance to the canvas parent gameobject.

    #region Setup

    private void Awake()
    {
        if (m_hideCanvasWhenInactive)
        {
            m_canvasParent = m_progressBar.canvas.gameObject;
            m_canvasParent.SetActive(false);
        }
    }
    private void OnEnable()
    {
        m_scriptInstance = m_scriptInstance == null ? GetComponent<TransformSelect>() : m_scriptInstance;
        if (m_scriptInstance!=null)
        {
            m_scriptInstance.m_onSelectingEvent.AddListener(OnStart);
            m_scriptInstance.m_onUnSelectingEvent.AddListener(OnStop);
            m_scriptInstance.m_onSelectEvent.AddListener(OnSelectComplete);
        }
    }
    private void OnDisable()
    {
        if (m_scriptInstance != null)
        {
            m_scriptInstance.m_onSelectingEvent.RemoveListener(OnStart);
            m_scriptInstance.m_onUnSelectingEvent.RemoveListener(OnStop);
            m_scriptInstance.m_onSelectEvent.RemoveListener(OnSelectComplete);
        }
    }
    #endregion



    private void OnStart()
    {
        if (m_hideCanvasWhenInactive) m_canvasParent.SetActive(true);
        StartCoroutine(MoveOverSeconds(m_scriptInstance.m_timeToFinishSelect));
    }

    private void OnStop()
    {
        if (m_hideCanvasWhenInactive) m_canvasParent.SetActive(false);
        if (m_progressBar != null) m_progressBar.fillAmount = 0;
        StopAllCoroutines();
    }

    private void OnSelectComplete()
    {
        if (m_progressBar != null) m_progressBar.fillAmount = 0;
        if (m_hideCanvasWhenInactive) m_canvasParent.SetActive(false);
    }



    private IEnumerator MoveOverSeconds(float seconds)
    {
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            if ( m_progressBar != null) m_progressBar.fillAmount = elapsedTime / seconds;


            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
