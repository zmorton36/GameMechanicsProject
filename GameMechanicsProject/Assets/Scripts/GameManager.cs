using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    Scene currScene;
    public bool IsPLaying { get; set; }
    public static GameManager Instance { get; private set; }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "LittleBrother")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        
    }

    
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currScene = scene;
    }

    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    void NextLevel()
    {
        SceneManager.LoadScene(currScene.buildIndex + 1);
    }

  
}
