﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu: MonoBehaviour{

    public void PlayGame()
    {
        SceneManager.LoadScene(2);//(SceneManager.GetActiveScene().buildIndex +1);
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
    
    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
