using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterManager : MonoBehaviour
{
    // Private 
    private ShelterBackend shelterBackend;
    private ShelterFrontend shelterFrontend;

    private UIManager uiManager;
    private AdoptDogOption adoptDogOption;

    private Queue<DogScript> dogsForAdoption;

    // Start is called before the first frame update
    void Start()
    {
        shelterBackend = transform.Find("ShelterBackend").GetComponent<ShelterBackend>();
        shelterFrontend = transform.Find("ShelterFrontend").GetComponent<ShelterFrontend>();
        uiManager = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();

        adoptDogOption = GameObject.FindGameObjectWithTag("AdoptDogOption").GetComponent<AdoptDogOption>();

        InstantiateShelter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InstantiateShelter()
    {
        dogsForAdoption = new Queue<DogScript>();
        shelterBackend.InitializeBackend();
        shelterFrontend.InitializeFrontend();
    }

    public ShelterBackend GetBackend()
    {
        return shelterBackend;
    }

    public ShelterFrontend GetFrontend()
    {
        return shelterFrontend;
    }

    public void AskToAdoptNewDog(DogScript nDog)
    {
        adoptDogOption.AddDogToAdopt();
        dogsForAdoption.Enqueue(nDog);

        if (uiManager.GetCurMenu() != "adoptDogOption")
        {
            uiManager.SwapMenus("adoptDogOption");
        }
    }

    public void AdoptDog()
    {
        shelterBackend.AddDogToShelter(dogsForAdoption.Dequeue());
        shelterFrontend.RefreshDogs();
    }

    public void DenyDog()
    {
        dogsForAdoption.Dequeue();
    }
}
