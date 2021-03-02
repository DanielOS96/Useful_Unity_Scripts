using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
/// <summary>
/// This script will:
/// <para>-Take a string of textmesh.</para>
/// <para>-Reveal one character at a time based on the 'charRevealRate' variable</para>
/// <para>-Unreveal the text based on the same variable.</para>
/// </summary>
public class TextMeshProScrollEffect : MonoBehaviour
{

    [SerializeField]
    private TextMeshProUGUI m_textMesh;        //Referance to the textmeshpro text to use.
    [SerializeField]
    private float m_charRevealRate = 0.1f;     //The letter reveal rate in seconds.
    [SerializeField]
    private bool m_revealOnAwake;              //Enable this to reveal text when scene starts.

    private int currentcCharIndex;             //The last letter that has been revealed.

    private void Start()
    {
        if (m_revealOnAwake) RevealText();
    }



    #region Control Methods
    /// <summary>
    /// Begin the revel of the text.
    /// </summary>
    public void RevealText()
    {
        StopAllCoroutines();
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(RevealTextCoroutine());
        }
    }

    /// <summary>
    /// Reverse the reveal of the text.
    /// </summary>
    public void UnRevealText()
    {
        StopAllCoroutines();
        if (this.gameObject.activeSelf)
        {
            StartCoroutine(UnRevealTextCoroutine());
        }
    }
    #endregion





    /// <summary>
    /// Reveal one letter at a time on a string of text.
    /// </summary>
    /// <returns></returns>
    private IEnumerator RevealTextCoroutine()
    {
        m_textMesh.ForceMeshUpdate();

        int numOfChars = m_textMesh.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (numOfChars + 1);
            m_textMesh.maxVisibleCharacters = visibleCount;

            currentcCharIndex = visibleCount;

            Debug.Log("R" + numOfChars);


            if (visibleCount >= numOfChars) yield break;


            counter += 1;

            yield return new WaitForSeconds(m_charRevealRate);
        }

    }

    /// <summary>
    /// Remove one letter at a time from the string of text 
    /// </summary>
    /// <returns></returns>
    private IEnumerator UnRevealTextCoroutine()
    {
        int counter = currentcCharIndex;

        while (true)
        {
            currentcCharIndex = counter;

            m_textMesh.maxVisibleCharacters = currentcCharIndex;

            if (currentcCharIndex <= 0) yield break;


            counter -= 1;

            yield return new WaitForSeconds(m_charRevealRate);
        }
    }



}
