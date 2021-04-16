using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    // PUBLIC
    public float Health = .5f; // Quality of dog over time
    public float Joy = 0.5f; // How Happy
    public float Hygiene = 0.5f; // How Clean
    // How Hydrated
    // How Hungry

    // Training Factors:
    // Personality Type
    // Time Invested
    // Average Dog Health
    
    // Training

    // PRIVATE
    private string dogName;
    private DogBreed _DogBreed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float GetJoy() { return Joy; }
    void SetJoy(float nJoy) { this.Joy = nJoy; }

    float GetHygiene() { return Hygiene; }
    void SetHygiene(float nHygiene) { this.Hygiene = nHygiene; }

    public string GetName() { return dogName; }
    public void SetName(string nDogName) { this.dogName = nDogName; }
}
