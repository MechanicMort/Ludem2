using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // set a bool for stating if the game is paused or not
    public static bool Paused = false;
    public GameObject pauseMenuUI;
    public Animator anim;

    

	
	// check to see if ESC key is pressed and what state the paused bool is in
	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                ResumeGame();
            }

            else
            {
                PauseGame();
            }
        }
	}

    //press ESC key during paused and return to game button
    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
    }

    //press ESC key to pause game
    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void ReturnMenu()
    {
        Debug.Log("Menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
