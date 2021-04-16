using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton
    private static GameManager _instance; // Main instance of game manager

    // Private
    private TimeManager timeManager;

    // Public
    public static GameManager Instance
    {
        get
        {
            if (GameManager._instance == null)
            {
                DontDestroyOnLoad(GameManager._instance);
                GameManager._instance = new GameManager();
            }
            return GameManager._instance;
        }

    }

    private bool _GameOver = false;

    private void Awake()
    {
        // Creates instance if not existing
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance)
        {
            Destroy(gameObject);
        }
    }

    private void InstantiateGame()
    {
        
    }

    private void Update()
    {
        // Check to end game
        if (!_GameOver)
        {
            Application.Quit();
        }
    }

    public void EndGame()
    {
        _GameOver = true;
    }

}
