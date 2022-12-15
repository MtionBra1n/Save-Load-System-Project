using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// reference to all ui objs
/// </summary>
public class MainMenuUiElements : MonoBehaviour
{
    /// <summary>
    /// reference to the main menu buttons
    /// </summary>
    public GameObject obj_buttonContinue, obj_buttonLoadGame;

    /// <summary>
    /// reference to the saveslots container
    /// </summary>
    public GameObject obj_loadContainer;

    /// <summary>
    /// reference to the saveslots container
    /// </summary>
    public GameObject obj_contentContainer;

    /// <summary>
    /// reference to the main menu container
    /// </summary>
    public GameObject obj_mainMenuContainer;

    /// <summary>
    /// reference to the save slot prefab
    /// this prefab will be instantiated, when the savedata will be loaded
    /// </summary>
    public GameObject saveSlotPrefab;
}
