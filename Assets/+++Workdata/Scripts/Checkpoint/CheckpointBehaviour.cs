using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// If the player enters a trigger of a checkpoint
/// A canas will be displayed and the bool canSave will be activated
/// The way of saving has to be reworked and only demonstrates how to save a game
/// </summary>
public class CheckpointBehaviour : MonoBehaviour
{
    /// <summary>
    /// reference to the canvas container 
    /// </summary>
    public GameObject canvasContainer;

    /// <summary>
    /// if the player enters a trigger
    /// </summary>
    /// <param name="other"> reference to the triggered obj </param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            canvasContainer.SetActive(true);
            other.GetComponent<PlayerController>().canSave = true;
        }
    }

    /// <summary>
    /// if the player exists a trigger
    /// </summary>
    /// <param name="other"> reference to the triggered obj </param>
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvasContainer.SetActive(false);
            other.GetComponent<PlayerController>().canSave = false;
        }
    }
}
