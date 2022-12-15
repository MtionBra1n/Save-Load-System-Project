using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// this script handles the scene loading
/// </summary>
public class LoadSceneManager : MonoBehaviour
{
    /// <summary>
    /// loads a new game
    /// </summary>
    public void LoadNewGame()
    {
        LoadSpecificScene("GameScene01");
    }

    /// <summary>
    /// loads a specific scene
    /// depends on the string gamesceneName
    /// </summary>
    /// <param name="gamesceneName"> reference gamesceneName</param>
    public void LoadSpecificScene(string gamesceneName)
    {
        SceneManager.LoadScene(gamesceneName);
    }
}
