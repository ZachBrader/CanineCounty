using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    // PUBLIC
    public float Joy = 0.5f;
    public float Hygiene = 0.5f;

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
