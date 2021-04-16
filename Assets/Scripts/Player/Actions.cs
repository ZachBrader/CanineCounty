using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    // Private
    private TimeManager timeManager;
    private UIManager uiManager;
    private bool isDogSelected;
    private Dog dogSelected;

    private bool canSleep = false;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!uiManager.GetMenuOpen())
        {
            // Matched to E key
            if (isDogSelected && Input.GetKeyDown(KeyCode.E))
            {
                OpenDogInteractionMenu();
            }
            else if (canSleep && Input.GetKeyDown(KeyCode.E))
            {
                ResetDay();
            }   
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            uiManager.SwapMenus("pauseMenu");
        }
    }

    #region Environment Methods

    private void ResetDay()
    {
        timeManager.startNewDay();
    }

    #endregion

    #region Player Actions
    public void PetDog()
    {
        Debug.Log("Petting dog");
        if (isDogSelected && uiManager.GetCurMenu() == "dogInteractionMenu")
        {
            timeManager.SpendTime(1f);

            Debug.Log("Pet the dog");
        }
    }
    #endregion

    #region Dog Methods
    public Dog getSelectedDog()
    {
        Debug.Log(dogSelected);
        if (dogSelected != null)
        {
            return dogSelected;
        }
        return null;
    }
    #endregion

    #region Menu Handlers
    public void OpenDogInteractionMenu()
    {
        // Matched to E key
        if (isDogSelected && uiManager.GetCurMenu() != "dogInteractionMenu")
        {
            uiManager.SwapMenus("dogInteractionMenu");
        }
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Dog"))
        {
            Debug.Log("Press P to pet dog");
            isDogSelected = true;
            dogSelected = collision.transform.GetComponent<Dog>();
        }
        else if (collision.collider.CompareTag("Bed"))
        {
            Debug.Log("Found bed");
            canSleep = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Dog"))
        {
            isDogSelected = false;
            dogSelected = null;
        }
        else if (collision.collider.CompareTag("Bed"))
        {
            canSleep = false;
        }
    }
}
