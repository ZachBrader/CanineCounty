using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    // Private
    private ShelterManager shelter;
    private ShelterBackend shelterBackend;
    

    // Start is called before the first frame update
    void Start()
    {
        shelter = GameObject.FindGameObjectWithTag("Shelter").GetComponent<ShelterManager>();
        shelterBackend = GameObject.FindGameObjectWithTag("ShelterBackend").GetComponent<ShelterBackend>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
