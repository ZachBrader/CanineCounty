using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdoptDogOption : MonoBehaviour
{
    // Private
    private bool isOpen = true;

    private GameObject adoptDogController;
    private UIManager uiManager;
    private ShelterManager shelter;

    private Text dogsToAdoptText;

    private int numDogsToAdopt = 0;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
        shelter = GameObject.FindGameObjectWithTag("Shelter").GetComponent<ShelterManager>();
        adoptDogController = transform.Find("AdoptDogControl").gameObject;

        dogsToAdoptText = adoptDogController.transform.Find("DogsToAdoptText").GetComponent<Text>();
        Debug.Log(dogsToAdoptText);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            dogsToAdoptText.text = numDogsToAdopt.ToString() + " dog(s) remaining";
        }
    }

    public void AddDogToAdopt()
    {
        numDogsToAdopt++;
    }
    
    public void AdoptionAccepted()
    {
        numDogsToAdopt--;
        shelter.AdoptDog();

        if (numDogsToAdopt <= 0)
        {
            uiManager.SwapMenus("mainUI");
        }
    }

    public void AdoptionDenied()
    {
        numDogsToAdopt--;
        shelter.DenyDog();

        if (numDogsToAdopt <= 0)
        {
            uiManager.SwapMenus("mainUI");
        }
    }

    public void Open()
    {
        isOpen = true;
        adoptDogController.SetActive(true);
    }

    public void Close()
    {
        isOpen = false;
        adoptDogController.SetActive(false);
    }
}
