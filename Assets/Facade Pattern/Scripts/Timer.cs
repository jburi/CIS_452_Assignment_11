/*
* Jake Buri
* Timer.cs
* Assignment 11
* Creates a countdown for the game
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    //Variables
	public float timeLeft = 10f;
	public Text text_box;

    //Used in Play_Facade.cs to prevent more than one game from starting
    public bool running = false;

    //Countdown Coroutine
    private IEnumerator Countdown()
    {
        //Test if countdown started
        Debug.Log("Start Countdown");
        running = true;

        //Reset time
        timeLeft = 10f;
        float duration = timeLeft;
        //Used as a timer
        float totalTime = 0;
        while (totalTime <= duration)
        {
            totalTime += Time.deltaTime;
            timeLeft -= Time.deltaTime;
            text_box.text = timeLeft.ToString("0.00");
            yield return null;
        }
        //Set timeLeft to zero to force the game to end
        timeLeft = 0.0f;
        running = false;
    }
}

