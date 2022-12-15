using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Debug Script
/// Loads the main menu by a given time
/// </summary>
public class LoadingScreenManager : MonoBehaviour
{
    /// <summary>
    /// reference to the loadSceneManager
    /// </summary>
    public LoadSceneManager loadSceneManager;


    private void OnEnable()
    {
#warning add Logo Animation and Delete Invoke and Method!!
        Debug.LogWarning("add Logo Animation and Delete Invoke and Method!!");
        Debug.Log("Load Logo Animation");
        Invoke("DebugLoadMainMenu", 2f);
    }

    /// <summary>
    /// Loads the main menu
    /// </summary>
    public void DebugLoadMainMenu()
    {
        loadSceneManager.LoadSpecificScene("MainMenu");
    }
}
