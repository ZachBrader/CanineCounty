using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteractionMenu : MonoBehaviour
{
    // Public
    public static bool isOpen;

    // Private
    private Actions playerActions;
    private Dog dog;
    private GameObject dogInteractionMenuController;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        playerActions = GameObject.FindGameObjectWithTag("Player").GetComponent<Actions>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        dogInteractionMenuController = transform.Find("DogInteractionMenuControl").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PetDog()
    {
        Debug.Log("Petting dog");
        Debug.Log(dog);
        if (dog != null)
        {
            playerActions.PetDog();
        }
    }

    public void ActivateDogInteractionMenu()
    {
        isOpen = true;
        Debug.Log("Turning on dog menu");
        dogInteractionMenuController.SetActive(true);
        OnOpen();
    }

    public void DeactivateDogInteractionMenu()
    {
        isOpen = false;
        Debug.Log("Turning off dog menu");
        dogInteractionMenuController.SetActive(false);
    }

    public void OnOpen()
    {
        if (playerActions == null)
        {
            Debug.Log("Player actions is null");
            return;
        }
        dog = playerActions.getSelectedDog();
        if (dog == null)
        {
        }
    }
}
