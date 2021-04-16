using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Public
    public static bool isOpen;

    // Private
    private GameObject pauseMenuController;
    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        pauseMenuController = transform.Find("PauseMenuControl").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivatePauseMenu()
    {
        Time.timeScale = 1f;
        isOpen = false;
        pauseMenuController.SetActive(false);
    }

    public void ActivatePauseMenu()
    {
        Time.timeScale = 0f;
        isOpen = true;
        pauseMenuController.SetActive(true);
    }
}
