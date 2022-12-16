using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

/// <summary>
/// handles all player information
/// </summary>
public class PlayerInformationManager : MonoBehaviour
{
    /// <summary>
    /// reference to the player Transform component
    /// </summary>
    public CharacterController characterController;

    /// <summary>
    /// reference to the playerFollowCamera
    /// </summary>
    public GameObject playerFollowCamera;

    /// <summary>
    /// reference to the thirdPersonController
    /// to lock the player movements if necessary
    /// </summary>
    private ThirdPersonController thirdPersonController;

    /// <summary>
    /// reference to the player healthpoints
    /// </summary>
    public int player_healthPoints;

    /// <summary>
    /// reference to the playerName
    /// </summary>
    public string playerName;

    /// <summary>
    /// sets the player Components
    /// </summary>
    private void Awake()
    {
        //onent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();
        characterController = GetComponent<CharacterController>();
    }

    /// <summary>
    /// saves all player information
    /// </summary>
    /// <param name="gameDataManager"> reference to the gameDataManager </param>
    public void SavesAllPlayerInformations(GameDataManager gameDataManager)
    {
        gameDataManager.currentSaveSlot.playerInformation.playerPos = transform.position;
    }

    /// <summary>
    /// loads all playerInformation
    /// </summary>
    /// <param name="currentSaveSlot"> reference to the saveSlot </param>
    public void LoadsAllPlayerInformations(SaveSlot currentSaveSlot)
    {
        // places the player on the saved position
        transform.position = currentSaveSlot.playerInformation.playerPos;

        playerFollowCamera.SetActive(true);
        characterController.enabled = true;
        thirdPersonController.enabled = true;

        PlayerMovement(true);
    }

    /// <summary>
    /// turns the script TirdPersonController on and off
    /// depends on the bool canMove
    /// </summary>
    /// <param name="canMove"> if false the player can't be moved </param>
    public void PlayerMovement(bool canMove)
    {
        if(canMove)
        {
            Time.timeScale = 1;
            
        }
        else
        {
            Time.timeScale = 0;
            
        }

        thirdPersonController.enabled = canMove;
    }
}
