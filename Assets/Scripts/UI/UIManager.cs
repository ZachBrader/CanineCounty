using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Public
    public bool showAction = true;
    public static bool menuOpen = false;

    // Private
    private TimeManager timeManager;

    private string curMenu;
    private DogInteractionMenu dogInteractionMenu;
    private MainUI mainUI;
    private PauseMenu pauseMenu;

    private AdoptDogOption adoptDogOption;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        dogInteractionMenu = GameObject.FindGameObjectWithTag("DogInteractionMenu").GetComponent<DogInteractionMenu>();
        mainUI = GameObject.FindGameObjectWithTag("MainUI").GetComponent<MainUI>();
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu").GetComponent<PauseMenu>();

        adoptDogOption = GameObject.FindGameObjectWithTag("AdoptDogOption").GetComponent<AdoptDogOption>();

        InitializeMenus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetCurMenu()
    {
        return curMenu;
    }

    #region Menu Handling
    // Using this to handle menus at beginning so not all are open at the same time
    public void InitializeMenus()
    {
        adoptDogOption.Close();
        pauseMenu.DeactivatePauseMenu();
        dogInteractionMenu.DeactivateDogInteractionMenu();
        curMenu = "mainUI";
    }

    public void SwapMenus(string nMenu)
    {
        if (curMenu == nMenu || nMenu == "")
        {
            return;
        }
        DeactivateOldMenu();

        curMenu = nMenu;

        ActivateNewMenu();

    }

    private void DeactivateOldMenu()
    {
        switch (curMenu)
        {
            case "mainUI":
                mainUI.DeactivateMainUI();
                break;
            case "dogInteractionMenu":
                menuOpen = false;
                dogInteractionMenu.DeactivateDogInteractionMenu();
                break;
            case "pauseMenu":
                menuOpen = false;
                pauseMenu.DeactivatePauseMenu();
                break;
            case "adoptDogOption":
                menuOpen = false;
                adoptDogOption.Close();
                break;
            default:
                break;
        }

    }

    private void ActivateNewMenu()
    {
        switch (curMenu)
        {
            case "mainUI":
                menuOpen = false;
                mainUI.ActivateMainUI();
                break;
            case "dogInteractionMenu":
                menuOpen = true;
                dogInteractionMenu.ActivateDogInteractionMenu();
                break;
            case "pauseMenu":
                menuOpen = true;
                pauseMenu.ActivatePauseMenu();
                break;
            case "adoptDogOption":
                menuOpen = true;
                adoptDogOption.Open();
                break;
            default:
                Debug.LogError("Could not swap to menu: " + curMenu);
                break;
        }

    }
    #endregion

    #region Get/Set
    public bool GetMenuOpen()
    {
        return menuOpen;
    }

    #endregion

}
