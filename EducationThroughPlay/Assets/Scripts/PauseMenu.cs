using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Holds the Pause Menu
    [SerializeField] GameObject pauseMenu;
    
    // Update is called once per frame
    void Update()
    {
        // If the player presses escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Open the pause menu
            pauseMenu.SetActive(true);
        }       
    }


    public void returnToHub()
    {
        SceneManager.LoadScene("Nav Hub");
    }

    // Called by the exit to desktop button
    public void exitButton()
    {
        // If its the unity editor quit
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif

        // Close the Application (works when built)
        Application.Quit();
    }
}
