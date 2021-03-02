using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Some basic scene controls.  
/// </summary>
public class SceneNavigation : MonoBehaviour
{
    /// <summary>
    /// Load scene by namme.
    /// </summary>
    /// <param name="sceneName">Scene Name</param>
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Reload current scene.
    /// </summary>
    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
