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
	public float timeLeft = 15f;
	public Text text_box;
    public bool running = false;

    private IEnumerator Countdown()
    {
        Debug.Log("Start Countdown");
        running = true;
        timeLeft = 15f;
        float duration = timeLeft; // 3 seconds you can change this 
                                   //to whatever you want
        float totalTime = 0;
        while (totalTime <= duration)
        {
            totalTime += Time.deltaTime;
            timeLeft -= Time.deltaTime;
            text_box.text = timeLeft.ToString("0.00");
            yield return null;
        }
        timeLeft = 0f;
        running = false;
    }
}

