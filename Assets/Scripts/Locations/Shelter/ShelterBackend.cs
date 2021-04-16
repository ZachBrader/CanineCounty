using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterBackend : MonoBehaviour
{
    // Public
    public static DogScript[] dogsInShelter;

    // Private
    private int numDogs;
    private int MAX_DOGS;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeBackend()
    {
        numDogs = 0;
        MAX_DOGS = 5;
        dogsInShelter = new DogScript[MAX_DOGS];

        /*for (int i = 0; i < MAX_DOGS; i++)
        {
            Dog newDog = new Dog();
            newDog.SetName(i.ToString());

            AddDogToShelter(newDog);
        }*/

        Debug.Log("Shelter has " + numDogs.ToString() + " in shelter");
    }

    public int getNumDogs()
    {
        return numDogs;
    }

    public int getMaxDogs()
    {
        return MAX_DOGS;
    }

    public DogScript[] getDogsInShelter()
    {
        return dogsInShelter;
    }

    public bool AddDogToShelter(DogScript nDog)
    {
        if (numDogs < MAX_DOGS)
        {
            for (int i = 0; i < MAX_DOGS; i++)
            {
                if (dogsInShelter[i] == null)
                {
                    Debug.Log("Found a spot for dog");
                    dogsInShelter[i] = nDog;
                    numDogs++;
                    return true;
                }
            } 
        }
        Debug.Log("Dog could not be accepted");
        return false;
    }

    public bool RemoveDogFromShelter(DogScript nDog)
    {
        if (numDogs > 0)
        {
            for (int i = 0; i < MAX_DOGS; i++)
            {
                if (dogsInShelter[i] != null && dogsInShelter[i] == nDog)
                {
                    Debug.Log("Found the dog");
                    dogsInShelter[i] = null;
                    numDogs--;
                    return true;
                }
            }
        }

        return false;
    }
}
