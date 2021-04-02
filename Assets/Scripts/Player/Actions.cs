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
        // Matched to E key
        if (isDogSelected && Input.GetKeyDown(KeyCode.E))
        {
            OpenDogInteractionMenu();
        }
        if (canSleep && Input.GetKeyDown(KeyCode.E))
        {
            ResetDay();
        }
    }

    #region Environment Methods

    private void ResetDay()
    {
        timeManager.startNewDay();
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

    public void PetDog()
    {
        Debug.Log("Petting dog");
        if (isDogSelected)
        {
            timeManager.SpendTime(1f);

            Debug.Log("Pet the dog");
        }
    }

    public void OpenDogInteractionMenu()
    {
        // Matched to E key
        if (isDogSelected)
        {
            uiManager.ShowDogInteractionMenu();
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
