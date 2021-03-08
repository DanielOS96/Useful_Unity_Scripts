using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This is a decorator class for TransformSelect script.
/// Handle the audio and fx for the transfrom select.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class TransformSelect_Effects : MonoBehaviour {
    [SerializeField]
    private TransformSelect m_scriptInstance;  //Referance to the transform select script instance.

    [Header("Audio Variables")]
    [SerializeField]
    private AudioClip m_selectingAudio;        //The audio that will play as transform is being selected.  
    [SerializeField]
    private AudioClip m_selectedAudio;         //The audio that will play when transform is fully selected. 
    [SerializeField]
    [Range(0, 1)] 
    private float m_selectingVolume = 0.05f;   //The volume of the audio that plays when selecting has begun.
    [SerializeField]
    [Range(0, 1)] 
    private float m_selectedVolume = 1f;       //The volume of the audio that plays when the tramsfom is selected.


    [Header("Particle Variables")]
    [SerializeField]
    private GameObject m_selectingParticles;   //The particle system that will play as the transform is being selected. 
    [SerializeField]
    private GameObject m_selectedParticles;    //The particle system will play when the transform has been selected.    


    private AudioSource m_src;  //Audio source referance.

    #region Setup
    private void OnEnable()
    {
        m_src = gameObject.GetComponent<AudioSource>();
        m_scriptInstance = m_scriptInstance == null ? GetComponent<TransformSelect>() : m_scriptInstance;

        if (m_scriptInstance != null)
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
        if (m_selectingAudio != null)
        {
            m_src.clip = m_selectingAudio;
            m_src.volume = m_selectingVolume;
            m_src.Play();
        }

        if (m_selectingParticles != null) ToggleParticles(m_selectingParticles, true);
    }
    private void OnStop()
    {
        m_src.Stop();

        if (m_selectingParticles != null) ToggleParticles(m_selectingParticles, false);
    }
    private void OnSelectComplete()
    {
        if (m_selectedAudio != null)
        {
            m_src.clip = m_selectedAudio;
            m_src.volume = m_selectedVolume;
            m_src.Play();
        }


        if (m_selectedParticles != null) ToggleParticles(m_selectedParticles, true);

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
