using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : MonoBehaviour
{
    /// <summary>
    /// reference to the playerInformationManager
    /// </summary>
    public PlayerInformationManager playerInformationManager;

    /// <summary>
    /// reference to the inGameUiElements
    /// </summary>
    public InGameUiElements inGameUiElements;

    /// <summary>
    /// 
    /// </summary>
    public bool pauseMenuActive;

    /// <summary>
    /// reference to the gameData Obj
    /// Needs to be found
    /// </summary>
    [HideInInspector]
    public GameObject gameDataObj;

    /// <summary>
    /// reference to the script LoadSceneManager
    /// loads all scenes
    /// </summary>
    [HideInInspector]
    public LoadSceneManager loadSceneManager;

    /// <summary>
    /// reference to the script GameDataManager
    /// keeps all of the save file information
    /// </summary>
    [HideInInspector]
    public GameDataManager gameDataManager;


    private void Start()
    {
        SetCursorState(true);


        // Starts a coroutine to find the gameData Manager
        StartCoroutine(FindGameManager());
    }

    /// <summary>
    /// finds the gameobject with the name GameManager inside your scene.
    /// Saves all necessary information 
    /// </summary>
    /// <returns></returns>
    IEnumerator FindGameManager()
    {
        gameDataObj = GameObject.Find("GameManager");

        yield return new WaitUntil(() => gameDataObj != null);

        gameDataManager = gameDataObj.GetComponent<GameDataManager>();
        loadSceneManager = gameDataObj.GetComponent<LoadSceneManager>();

        yield return true;

        // Loads all Data
        playerInformationManager.LoadsAllPlayerInformations(gameDataManager.currentSaveSlot);
    }

    /// <summary>
    /// sets up the cursor state
    /// </summary>
    /// <param name="newState"> if true the cursor will be hidden and locked </param>
    private void SetCursorState(bool newState)
    {
        Cursor.visible = !newState;
        Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
    }

    /// <summary>
    /// Controls the ingame Ui |
    /// 0 -> ingame menu |
    /// 1 -> pause menu |
    /// 2 -> option menu |
    /// </summary>
    /// <param name="sceneIndex"> reference to the ui menu </param>
    public void OpenUiScene(int sceneIndex)
    {
        TurnAllUiContainersOff();
        switch (sceneIndex)
        {
            case 0: // Ingame Menu
                //inGameUiElements.ingameContainer.SetActive(true);
                SetCursorState(true);
                playerInformationManager.PlayerMovement(true); // player can move again
                break;

            case 1: // Pause Menu
                inGameUiElements.pauseMenuContainer.SetActive(true);
                SetCursorState(false);
                break;

            case 2: // Option Menu
                inGameUiElements.optionContainer.SetActive(true);
                SetCursorState(false);
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// Turns all Ui elements inside the ingameUiElements Script off
    /// </summary>
    private void TurnAllUiContainersOff()
    {
        inGameUiElements.pauseMenuContainer.SetActive(false);
        //inGameUiElements.optionContainer.SetActive(false);
        //inGameUiElements.ingameContainer.SetActive(false);
    }
}
