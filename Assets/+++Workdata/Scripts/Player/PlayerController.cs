using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameActions inputActions;

    /// <summary>
    /// if true the player can save the game
    /// </summary>
    public bool canSave;

    /// <summary>
    /// reference to the playerInformationManager
    /// </summary>
    public PlayerInformationManager playerInformationManager;

    /// <summary>
    /// reference to the inGameMenuManager
    /// </summary>
    public InGameManager inGameManager;

    /// <summary>
    /// enables the inputactions
    /// </summary>
    private void OnEnable()
    {
        inputActions.Enable();
    }

    /// <summary>
    /// disables the inputactions
    /// </summary>
    private void OnDisable()
    {
        inputActions.Disable();
    }

    /// <summary>
    /// Loads Input Methods
    /// </summary>
    private void Awake()
    {
        inputActions = new GameActions();

        inputActions.PlayerController.Interact.performed += ctx => Interact();
        inputActions.PlayerController.Escape.performed += ctx => EscapePress();
    }

    /// <summary>
    /// gets called when the player presses E
    /// </summary>
    void Interact()
    {
        if (canSave)
        {
            canSave = false;

            // Saves all Data
            inGameManager.playerInformationManager.SavesAllPlayerInformations(inGameManager.gameDataManager);
            inGameManager.gameDataManager.SaveGame();
        }
    }

    /// <summary>
    /// gets called when the player presses ESC
    /// </summary>
    void EscapePress()
    {
        // negates the bool pauseMenuActive
        inGameManager.pauseMenuActive = !inGameManager.pauseMenuActive;

        if (inGameManager.pauseMenuActive) // optionsmenu open
        {
            playerInformationManager.PlayerMovement(false);

            inGameManager.OpenUiScene(1);
        }
        else // optionsmenu close
        {
            playerInformationManager.PlayerMovement(true);
            inGameManager.OpenUiScene(0);
        }
    }
}
