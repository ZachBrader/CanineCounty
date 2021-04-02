using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Public
    public bool showAction = true;

    // Private
    private Text timeText;
    private Text dateText;
    private GameObject actionText; // Game Object for action text
    private TimeManager timeManager;

    private GameObject curMenu;
    private GameObject dogInteractionMenu;
    private GameObject mainUI;

    // Start is called before the first frame update
    void Start()
    {
        timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>();
        dateText = GameObject.FindGameObjectWithTag("DateText").GetComponent<Text>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        dogInteractionMenu = GameObject.FindGameObjectWithTag("DogInteractionMenu");
        mainUI = GameObject.FindGameObjectWithTag("MainUI");

        ShowDogInteractionMenu();
        ShowMainUI();

    }

    // Update is called once per frame
    void Update()
    {
        if (mainUI.activeSelf)
        {
            timeText.text = timeManager.getTimeUsed().ToString() + " hours / " + timeManager.totalTime.ToString() + " hours";
            dateText.text = "Day " + timeManager.getDate().ToString() + " of " + timeManager.getFinalDate().ToString() + " days";
        }
    }

    public void ShowMainUI()
    {
        Debug.Log("Showing main ui");
        if (curMenu != null) { curMenu.SetActive(false); }
        mainUI.SetActive(true);
        curMenu = mainUI;
    }

    public void ShowDogInteractionMenu()
    {
        Debug.Log("Showing dog menu");
        if (curMenu != null) { curMenu.SetActive(false); }
        dogInteractionMenu.SetActive(true);
        curMenu = dogInteractionMenu;

        dogInteractionMenu.transform.parent.GetComponent<DogInteractionMenu>().OnOpen();
    }

    /*public void ShowPromptForAction(string newActionText = "")
    {
        actionText.SetActive(true);
        actionText.GetComponent(Text).text = newActionText;
    }*/
}
