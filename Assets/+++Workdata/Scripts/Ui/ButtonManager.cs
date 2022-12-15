using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script has all of the button functions
/// Those methods will only be called by a button
/// </summary>
public class ButtonManager : MonoBehaviour
{
    /// <summary>
    /// if the button newGame is pressed a new game will be created
    /// </summary>
    public void Button_NewGame(MainMenuManager mainMenuManager)
    {
        mainMenuManager.gameDataManager.NewGame();
    }

    /// <summary>
    /// if the button loadGame is pressed
    /// the load screen container will be visible
    /// the main menu will be invisible
    /// </summary>
    /// <param name="mainMenuManager"> reference to the mainMenuManager </param>
    public void Button_LoadMenu(MainMenuManager mainMenuManager)
    {
        mainMenuManager.ChangeUiScene(1);
    }

    /// <summary>
    /// if the button Close at the load menu is pressed
    /// the load screen container will be turned off
    /// the main menu will be turned on
    /// </summary>
    /// <param name="mainMenuManager"> reference to the mainMenuManager </param>
    public void Button_CloseLoadMenu(MainMenuManager mainMenuManager)
    {
        mainMenuManager.ChangeUiScene(0);
    }

    /// <summary>
    /// if the button continueGame is pressed a game will be loaded by the saved lastSaveSlotId
    /// </summary>
    public void Button_ContinueGame(MainMenuManager mainMenuManager)
    {
        Debug.Log("Continue Game");

        mainMenuManager.gameDataManager.LoadGame(mainMenuManager.gameDataManager.gameData.lastSaveSlotId);

    }

    /// <summary>
    /// if the button options is pressed
    /// the options screen container will be visible
    /// </summary>
    public void Button_Options()
    {

    }

    /// <summary>
    /// Closes the pause menu
    /// </summary>
    /// <param name="inGameManager"> reference to the inGameManager </param>
    public void Button_Resume(InGameManager inGameManager)
    {
        inGameManager.OpenUiScene(0);
    }

    /// <summary>
    /// Back to the main Menu
    /// </summary>
    /// <param name="inGameManager">reference to the inGameManager </param>
    public void Button_BackToMainMenu(InGameManager inGameManager)
    {
        inGameManager.loadSceneManager.LoadSpecificScene("MainMenu");
    }

    /// <summary>
    /// Quits the game
    /// </summary>
    public void Button_QuitGame()
    {
        Application.Quit();
    }
}
