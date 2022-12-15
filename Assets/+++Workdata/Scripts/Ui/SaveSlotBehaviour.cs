using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This script is assigned to the saveslotprefab
/// All important setup functions and button methods are placed here.
/// </summary>
public class SaveSlotBehaviour : MonoBehaviour
{
    /// <summary>
    /// reference to the current image for displaying the saveslot
    /// </summary>
    public Image saveSlotImage;

    /// <summary>
    /// different text components
    /// </summary>
    public TextMeshProUGUI text_sceneId, text_sceneName, text_date;

    /// <summary>
    /// the sceneId for loading the saved game
    /// </summary>
    public int sceneId;

    /// <summary>
    /// reference to the gameDataManager
    /// </summary>
    public GameDataManager gameDataManager;

    /// <summary>
    /// sets up the saveslot prefab by changing the:
    ///
    /// image *not implemented yet*
    /// text components
    /// assigning gameDataManager
    ///
    /// </summary>
    /// <param name="sceneId"> the selected scene id </param>
    /// <param name="gameDataManager">reference to the gameDataManager</param>
    /// <param name="sceneName"> current scene name </param>
    /// <param name="date"> save date</param>
    public void SetUpSaveSlotPrefab(int sceneId, GameDataManager gameDataManager, string sceneName, string date)
    {
        this.gameDataManager = gameDataManager;

        this.sceneId = sceneId;
        int displaySceneId = sceneId + 1;
        text_sceneId.text = displaySceneId.ToString();
        text_sceneName.text = sceneName;
        text_date.text = date;
    }

    /// <summary>
    /// gets called by a button
    /// loads the game
    /// </summary>
    public void Button_LoadGame()
    {
        gameDataManager.LoadGame(sceneId);
    }

    /// <summary>
    /// gets called by a button
    /// deletes a game
    /// </summary>
    public void Button_DeleteGame()
    {
        gameDataManager.DeleteGame(sceneId);
    }
}
