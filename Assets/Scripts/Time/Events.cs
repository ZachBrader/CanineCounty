using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    // Private
    private ShelterManager shelter;
    private ShelterBackend shelterBackend;

    private Actions playerActions;
    

    // Start is called before the first frame update
    void Start()
    {
        shelter = GameObject.FindGameObjectWithTag("Shelter").GetComponent<ShelterManager>();
        shelterBackend = GameObject.FindGameObjectWithTag("Shelter").transform.Find("ShelterBackend").GetComponent<ShelterBackend>();
        playerActions = GameObject.FindGameObjectWithTag("Player").GetComponent<Actions>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateEventsBasedOnTimeUsed(float timeUsed)
    {
        if (timeUsed >= 2 && timeUsed < 3)
        {
            SpawnStrayDogs();
        }

        if (timeUsed >= 10)
        {
            playerActions.EnableSleep();
        }


    }

    public void SpawnStrayDogs()
    {
        int numberOfDogs = Random.Range(1, 2);

        for (int i = 0; i < numberOfDogs; i++)
        {
            DogScript dog = new DogScript();

            shelter.AskToAdoptNewDog(dog);
        }
    }

}
