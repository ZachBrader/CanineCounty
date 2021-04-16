using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    // Public
    public static bool isOpen;

    // Private
    private Text timeText;
    private Text dateText;
    private TimeManager timeManager;

    private GameObject mainUIController;
    private GameObject optionPanelController;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        mainUIController = transform.Find("MainUIControl").gameObject;
        optionPanelController = transform.Find("OptionPanelControl").gameObject;
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        timeText = GameObject.FindGameObjectWithTag("TimeText").GetComponent<Text>();
        dateText = GameObject.FindGameObjectWithTag("DateText").GetComponent<Text>();
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mainUIController.activeSelf)
        {
            timeText.text = timeManager.getTimeUsed().ToString() + " hours / " + timeManager.totalTime.ToString() + " hours";
            dateText.text = "Day " + timeManager.getDate().ToString() + " of " + timeManager.getFinalDate().ToString() + " days";
        }
    }

    public void ActivateMainUI()
    {
        isOpen = true;
        mainUIController.SetActive(true);
    }

    public void DeactivateMainUI()
    {
        isOpen = false;
        mainUIController.SetActive(false);
    }

    public void ActivateOptionPanel()
    {
        optionPanelController.SetActive(true);
    }

    public void DeactivateOptionPanel()
    {
        optionPanelController.SetActive(false);
    }
}
