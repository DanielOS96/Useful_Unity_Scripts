using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script will:
/// -Handle the audio and fx for the transfrom select.
/// -This is a decorator script for transfrom select.
/// </summary>
public class TransformSelect_Effects : MonoBehaviour {

    public TransformSelect scriptInstance;  //Referance to the transform select script instance.

    [Header("Audio Variables")]
    public AudioClip selectingAudio;                      //The audio that will play as transform is being selected.  
    public AudioClip selectedAudio;                       //The audio that will play when transform is fully selected. 
    [Range(0, 1)] public float selectingVolume = 0.05f;   //The volume of the audio that plays when selecting has begun.
    [Range(0, 1)] public float selectedVolume = 1f;       //The volume of the audio that plays when the tramsfom is selected.


    [Header("Particle Variables")]
    public GameObject selectingParticles;   //The particle system that will play as the transform is being selected.        
    public GameObject selectedParticles;    //The particle system will play when the transform has been selected.    


    AudioSource src;

    #region Setup
    private void OnEnable()
    {
        src = (gameObject.GetComponent<AudioSource>() == null) ? gameObject.AddComponent<AudioSource>() : gameObject.GetComponent<AudioSource>();
        scriptInstance = scriptInstance == null ? GetComponent<TransformSelect>() : scriptInstance;

        if (scriptInstance != null)
        {
            scriptInstance.onSelectingEvent.AddListener(OnStart);
            scriptInstance.onUnSelectingEvent.AddListener(OnStop);
            scriptInstance.onSelectEvent.AddListener(OnSelectComplete);
        }
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
        if (selectingAudio != null)
        {
            src.clip = selectingAudio;
            src.volume = selectingVolume;
            src.Play();
        }

        if (selectingParticles != null) ToggleParticles(selectingParticles, true);
    }
    private void OnStop()
    {
        src.Stop();

        if (selectingParticles != null) ToggleParticles(selectingParticles, false);
    }
    private void OnSelectComplete()
    {
        if (selectedAudio != null)
        {
            src.clip = selectedAudio;
            src.volume = selectedVolume;
            src.Play();
        }


        if (selectedParticles != null) ToggleParticles(selectedParticles, true);

    }





    //Toggle a particle system on or off.
    private void ToggleParticles(GameObject particles, bool on)
    {
        //Check if gameobject has a particle system.
        if (particles.GetComponent<ParticleSystem>() != null)
        {
            if (on) particles.GetComponent<ParticleSystem>().Play();
            else particles.GetComponent<ParticleSystem>().Stop();
        }
        //Check if gameobject has children with particle system.
        if (particles.gameObject.transform.childCount > 0)
        {
            foreach (Transform child in particles.gameObject.transform)
            {
                if (child.GetComponent<ParticleSystem>() != null)
                {
                    if (on) child.GetComponent<ParticleSystem>().Play();
                    else child.GetComponent<ParticleSystem>().Stop();
                }
            }
        }
    }


}
