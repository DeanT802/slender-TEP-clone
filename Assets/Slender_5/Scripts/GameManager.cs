using UnityEngine;
using UnityEngine.SceneManagement; // For loading scenes
using System.Collections;  // For coroutines and IEnumerator
using UnityEngine.UI; // For accessing UI elements

public class GameManager : MonoBehaviour
{
    public GameLogic Page; // Reference to GameLogic script
    public GameObject winUI;  // Reference to the "You Win!" UI panel

    public SlenderPlayerController playerController; // Reference to the SlenderPlayerController script

    private void Update()
    {
        // If the player reaches pageCount of 8, trigger the win sequence
        if (Page.pageCount == 8)
        {
            TriggerWin();
        }
    }

    // This function shows the "You Win!" UI and then optionally loads a new scene or restarts the level.
    private void TriggerWin()
    {
        // Pause the game (stop all gameplay mechanics)
        Time.timeScale = 0f;

        // Disable player controls (movement and camera) by disabling the script
        playerController.enabled = false;

        // Show the "You Win!" UI
        winUI.SetActive(true);

        // Start a coroutine to delay the scene change
        StartCoroutine(DelayAndLoadMainMenu());
    }

    // Coroutine to wait for 5 seconds before returning to the main menu
    private IEnumerator DelayAndLoadMainMenu()
    {
        // Wait for 5 seconds
        yield return new WaitForSecondsRealtime(5f);

        // Unlock the cursor and make it visible when going to the main menu
        Cursor.lockState = CursorLockMode.None;  // Unlock the cursor
        Cursor.visible = true;  // Make the cursor visible

        // After 5 seconds, load the main menu (or any other scene you want)
        SceneManager.LoadScene("MainM");  // Replace with your main menu scene name

        // Resume the game after returning to the main menu
        Time.timeScale = 1f;
    }
}
