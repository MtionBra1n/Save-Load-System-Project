using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


/// <summary>
/// Keeps track of all of the gamedata
///
/// Reference to all save and load methods
///
/// Loads the game Data when the object will be enabled
/// </summary>
public class GameDataManager : MonoBehaviour
{
    /// <summary>
    /// reference to the LoadSceneManager
    /// </summary>
    public LoadSceneManager loadSceneManager;

    /// <summary>
    /// The GameData is the main class of the save files of the game
    /// </summary>
    public GameData gameData;

    /// <summary>
    /// displays the CurrentSaveSlot
    /// Keep in mind to save this reference into the specific GameData Saveslot List
    /// </summary>
    public SaveSlot currentSaveSlot;

    /// <summary>
    /// reference to the current selected saveslot id
    /// </summary>
    public int saveslotId;

    /// <summary>
    /// reference to the filename of the save data text file
    /// </summary>
    public string filename;

    /// <summary>
    /// path folder url with the filename
    /// </summary>
    string url;



    private void OnEnable()
    {
        // gameobject wont be destroyed
        DontDestroyOnLoad(gameObject);

        LoadJsonFromFile();
    }

    /// <summary>
    /// Reads all information from the given url if this specific file exists
    /// </summary>
    public void LoadJsonFromFile()
    {
        url = Application.persistentDataPath + "/" + filename + ".txt";

        gameData = new GameData();

        if (File.Exists(url))
        {
            string json = File.ReadAllText(url);

            gameData = JsonUtility.FromJson<GameData>(json);
            return;
        }
        
        gameData.saveSlots = new List<SaveSlot>();
    }

    /// <summary>
    /// Creates a new game
    /// saves all necessary save slot data
    /// </summary>
    public void NewGame()
    {
        SaveSlot newSaveSlot = new SaveSlot();

        newSaveSlot.dateTime = DateTime.Now.ToString();

        newSaveSlot.sceneName = "GameScene01";
        newSaveSlot.playerInformation = new PlayerInformation();
        gameData.saveSlots.Add(newSaveSlot);

        currentSaveSlot = newSaveSlot;

        // saves the save slot id
        saveslotId = gameData.saveSlots.Count - 1;
        gameData.lastSaveSlotId = saveslotId;

        SaveGameData();

        loadSceneManager.LoadNewGame();
    }

    /// <summary>
    /// saves the current game
    /// the currentsaveslot will be copied into the game data by the given saveslotId
    /// </summary>
    public void SaveGame()
    {
        gameData.saveSlots[saveslotId] = currentSaveSlot;
        SaveGameData();
    }

    /*
    public void DuplicateSaveSlot(int index)
    {
        SaveSlot newSaveSlot = gameData.saveSlots[index];

        gameData.saveSlots.Add(newSaveSlot);

        SaveGameData();
    }
    */

    /// <summary>
    /// Writes all game data into the gamefile
    /// </summary>
    public void SaveGameData()
    {
        string jsonstring = JsonUtility.ToJson(gameData);
        File.WriteAllText(url, jsonstring);
        Debug.Log("Game saved");
    }

    /// <summary>
    /// Loads the game by the given slotId
    /// The slotId will be handed over by the given saveSlot selection
    /// </summary>
    /// <param name="slotId"> reference to the saveslot selection </param>
    public void LoadGame(int slotId)
    {
        saveslotId = slotId;
        currentSaveSlot = gameData.saveSlots[saveslotId];
        loadSceneManager.LoadSpecificScene(gameData.saveSlots[slotId].sceneName);
    }

    /// <summary>
    /// Deletes the game by the given slotId
    /// which will be delivered by the given saveSlot selection
    /// </summary>
    /// <param name="slotId">reference to the saveslot selection </param>
    public void DeleteGame(int slotId)
    {
        gameData.saveSlots.RemoveAt(slotId);
        SaveGameData();


        // Create all Saveslots Button new
    }


}
