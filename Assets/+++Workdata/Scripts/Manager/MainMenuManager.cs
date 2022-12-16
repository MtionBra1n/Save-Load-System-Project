using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    /// <summary>
    /// reference to the script MainMenuUiElements
    /// has all necessary ui references 
    /// </summary>
    public MainMenuUiElements mainMenuUiElements;

    /// <summary>
    /// reference to the gameData Obj
    /// Needs to be found
    /// </summary>
    public GameObject gameDataObj;

    /// <summary>
    /// reference to the script GameDataManager
    /// keeps all of the save file information
    /// </summary>
    public GameDataManager gameDataManager;

    /// <summary>
    /// reference to the script LoadSceneManager
    /// loads all scenes
    /// </summary>
    public LoadSceneManager loadSceneManager;


    private void OnEnable()
    {
        //starts the coroutine FindGameManager
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

        SetUpMainMenu();

        yield return true;
    }

    /// <summary>
    /// Gets called from the coroutine FindGameManager
    /// The main menu ui elements will be changed
    /// it depends on the current game data
    /// </summary>
    public void SetUpMainMenu()
    {
        //is true, if the gamedata has at least one saveslot
        if (gameDataManager.gameData.saveSlots.Count > 0)
        {
            ButtonSetUp(true, mainMenuUiElements.obj_buttonContinue);

            ButtonSetUp(true, mainMenuUiElements.obj_buttonLoadGame);

            SetUpLoadContainer();
            return;
        }

        // No Saveslots
        ButtonSetUp(false, mainMenuUiElements.obj_buttonContinue);

        ButtonSetUp(false, mainMenuUiElements.obj_buttonLoadGame);

    }

    /// <summary>
    /// Gets called from the function SetUpMainMenu which gets called by the coroutine
    /// Sets up the load container, by creating saveslot prefabs and set them a parent of the contentContainer
    /// </summary>
    public void SetUpLoadContainer()
    {
        for (int i = 0; i < gameDataManager.gameData.saveSlots.Count; i++)
        {
            GameObject newSaveSlotContainer = Instantiate(mainMenuUiElements.saveSlotPrefab);
            newSaveSlotContainer.transform.SetParent(mainMenuUiElements.obj_contentContainer.transform);
            newSaveSlotContainer.transform.localScale = Vector3.one;


            newSaveSlotContainer.GetComponent<SaveSlotBehaviour>().SetUpSaveSlotPrefab(i, gameDataManager,
                gameDataManager.gameData.saveSlots[i].sceneName, gameDataManager.gameData.saveSlots[i].dateTime);
        }
    }


    /// <summary>
    /// Sets up a given ButtonObj.
    /// Edits the Button and CanvasGroup component
    /// depends on the bool interactable
    /// </summary>
    /// <param name="interactable"> bool is true when button shall be active</param>
    /// <param name="buttonObj"> reference to the buttonObj</param>
    private void ButtonSetUp(bool interactable, GameObject buttonObj)
    {
        if (interactable)
        {

            buttonObj.GetComponent<Button>().interactable = true;
            buttonObj.GetComponent<CanvasGroup>().alpha = 1;
        }
        else
        {
            buttonObj.GetComponent<Button>().interactable = false;
            buttonObj.GetComponent<CanvasGroup>().alpha = .3f;
        }
    }


    /// <summary>
    /// Controls the mainMenu Ui|
    /// 0 -> Main menu |
    /// 1 -> Load menu |
    /// </summary>
    /// <param name="sceneIndex"> reference to the ui menu </param>
    public void ChangeUiScene(int sceneIndex)
    {
        TurnAllUiContainersOff();
        switch (sceneIndex)
        {
            case 0: // Main Menu
                mainMenuUiElements.obj_mainMenuContainer.SetActive(true);
                break;

            case 1: // Load Menu
                mainMenuUiElements.obj_loadContainer.SetActive(true);
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
        mainMenuUiElements.obj_loadContainer.SetActive(false);
        mainMenuUiElements.obj_mainMenuContainer.SetActive(false);
    }
}
