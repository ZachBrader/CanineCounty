using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteractionMenu : MonoBehaviour
{
    private Actions playerActions;
    private Dog dog;
    private GameObject dogInteractionMenuParent;
    private GameObject dogInteractionMenu;

    private UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        playerActions = GameObject.FindGameObjectWithTag("Player").GetComponent<Actions>();

        dogInteractionMenu = this.transform.parent.gameObject;
        dogInteractionMenuParent = GameObject.FindGameObjectWithTag("DogInteractionMenu");
        //timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public void PetDog()
    {
        Debug.Log("Petting dog");
        Debug.Log(dog);
        if (dog != null)
        {
            playerActions.PetDog();
        }
    }
}
