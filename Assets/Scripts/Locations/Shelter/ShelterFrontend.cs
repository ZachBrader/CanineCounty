using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelterFrontend : MonoBehaviour
{
    // Public 
    public GameObject kennelPrefab;
    public GameObject dogPrefab;
    public Vector2 startingLocation;

    // Private
    private ShelterBackend shelterBackend;
    private GameObject DogKennels;
    private GameObject Dogs;

    private bool isInstantiated = false;

    // Start is called before the first frame update
    void Start()
    {
        shelterBackend = transform.parent.Find("ShelterBackend").GetComponent<ShelterBackend>();
        DogKennels = transform.Find("DogKennels").gameObject;
        Dogs = transform.Find("Dogs").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isInstantiated)
        {
            InstantiateDogKennels();
            isInstantiated = true;
        }
    }

    void InstantiateDogKennels()
    {
        Debug.Log(shelterBackend.getMaxDogs());
        for (int i = 0; i < shelterBackend.getMaxDogs(); i++)
        {
            Debug.Log("Making new kennel");
            GameObject newKennel = Instantiate(kennelPrefab, new Vector3(startingLocation.x + i * 2, startingLocation.y, 0), Quaternion.identity);
            newKennel.transform.SetParent(DogKennels.transform);
            newKennel.GetComponent<SpriteRenderer>().sortingLayerName = "Setting";
        }

        for (int i = 0; i < shelterBackend.getNumDogs(); i++)
        {
            Debug.Log("Making new dog");
            GameObject newDog = Instantiate(dogPrefab, new Vector3(startingLocation.x + i * 2, startingLocation.y, 0), Quaternion.identity);
            newDog.transform.SetParent(Dogs.transform);
            // newDog.GetComponent<SpriteRenderer>().sortingLayerName;
        }
    }
}
