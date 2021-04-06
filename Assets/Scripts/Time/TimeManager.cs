using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Public
    public float totalTime = 10; // Total time player has in a day
    private int finalDay = 31; // Last day player has before game over

    // Private
    private int curDay = 1; // Current day for player
    private float timeUsed = 0; // Amount of time player used up 
    private GameManager gameManager;

    private Events inGameEvents;

    public void Start()
    {
        gameManager = GameManager.Instance;

        inGameEvents = GetComponent<Events>();
    }

    public void Update()
    {
        /*if (timeUsed >= totalTime)
        {
            startNewDay();
        }*/
    }

    // Returns time used for player
    public float getTimeUsed()
    {
        return timeUsed;
    }

    // Keeps track of players using time
    public void SpendTime(float timeSpent)
    {
        timeUsed += timeSpent;
    }

    // Checks whether player has enough time to preform action
    public bool canDoAction(float possibleTime)
    {
        if (possibleTime + timeUsed > totalTime)
            return false;
        return true;
    }

    // Starts new day
    public void startNewDay(int timeForDay = 10)
    {
        curDay++;
        timeUsed = 0; // Reset time used
        totalTime = timeForDay; // Set next days date

        inGameEvents.SpawnStrayDogs();
    }

    // Returns current day for player
    public int getDate()
    {
        return curDay;
    }

    public int getFinalDate()
    {
        return finalDay;
    }
}
