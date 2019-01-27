using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

	private void Start()
	{
		Cursor.visible = false;
	}
	// Update is called once per frame

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			
            if (GameIsPaused)
            {
				Cursor.visible = true;
                Resume();
            }
            else
            {
				Cursor.visible = false;
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ReturntoMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
