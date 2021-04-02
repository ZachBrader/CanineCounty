using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bed : MonoBehaviour
{
    // Private
    private TimeManager timeManager;

    // Start is called before the first frame update
    void Start()
    {
        timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
