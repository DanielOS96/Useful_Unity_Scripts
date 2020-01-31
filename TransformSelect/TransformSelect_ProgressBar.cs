using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// This is a decorator class for Transform select.
/// This script will show a progress bar to indicate the 
/// transfroms current progress to its target.
/// </summary>
public class TransformSelect_ProgressBar : MonoBehaviour {


    public TransformSelect scriptInstance;  //Referance to the transform select script instance.

    [Header("Progress Bar Variables")]
    public bool hideBarWhenInactive;        //Show the progress bar when the transform select is not active.
    public Image progressBar;               //Referance to the progress bar.
    public Canvas progressBarCanvas;        //Referance to the progress bar canvas.

    #region Setup
    private void OnEnable()
    {
        scriptInstance = scriptInstance == null ? GetComponent<TransformSelect>() : scriptInstance;
        if (scriptInstance!=null)
        {
            scriptInstance.onSelectingEvent.AddListener(OnStart);
            scriptInstance.onUnSelectingEvent.AddListener(OnStop);
            scriptInstance.onSelectEvent.AddListener(OnSelectComplete);
        }
        if (hideBarWhenInactive && progressBarCanvas != null) progressBarCanvas.gameObject.SetActive(false);

    }
    private void OnDisable()
    {
        if (scriptInstance != null)
        {
            scriptInstance.onSelectingEvent.RemoveListener(OnStart);
            scriptInstance.onUnSelectingEvent.RemoveListener(OnStop);
            scriptInstance.onSelectEvent.RemoveListener(OnSelectComplete);

        }
    }
    #endregion



    private void OnStart()
    {
        if (hideBarWhenInactive && progressBarCanvas != null) progressBarCanvas.gameObject.SetActive(true);
        StartCoroutine(MoveOverSeconds(scriptInstance.timeToFinishSelect));
    }

    private void OnStop()
    {
        if (hideBarWhenInactive && progressBarCanvas != null) progressBarCanvas.gameObject.SetActive(false);
        if (progressBar != null) progressBar.fillAmount = 0;
        StopAllCoroutines();
    }

    private void OnSelectComplete()
    {
        if (progressBar != null) progressBar.fillAmount = 0;
        if (hideBarWhenInactive && progressBarCanvas != null) progressBarCanvas.gameObject.SetActive(false);
    }



    private IEnumerator MoveOverSeconds(float seconds)
    {
        float elapsedTime = 0;

        while (elapsedTime < seconds)
        {
            if ( progressBar != null) progressBar.fillAmount = elapsedTime / seconds;


            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }

}
