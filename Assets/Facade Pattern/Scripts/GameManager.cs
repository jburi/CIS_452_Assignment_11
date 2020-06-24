/*
* Jake Buri
* GameManager.cs
* Assignment 11
* Handles all of the functions for the facade
*/

using FPSControllerLPFP;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Game Prefabs
    public GameObject target;
    public List<Transform> targetSpawnpoints;
    public Text winLoss;

    //Variables
    public List<MyTargetScript> targets;
    public Timer gameTimer;

    /* Tried to make a constructor but can't with monobehavior
    public GameManager(GameObject target, List<Transform> transforms, Text text, List<MyTargetScript> targetScripts, Timer timer)
    {
        this.target = target;
        this.targetSpawnpoints = transforms;
        this.winLoss = text;
        this.targets = targetScripts;
        this.gameTimer = timer;
    }
    */

    private void Update()
    {
        //Checks if every target has been hit (only if targets exist)
        if (IsEveryTargetHit() == true)
        {
            EndGameWin();
        }
        //If all of the targets are not hit in time then you lose
        else if (gameTimer.timeLeft == 0)
        {
            EndGameLose();
        }
    }

    //Facade function
    public void StartGame()
    {
        //Test Collision function in Play_Facade.cs
        Debug.Log("Start Game");
        
        //Game Start functions
        SpawnTargets();
        StartTimer();
    }

    //Spawn the targets at the spawnpoints
    void SpawnTargets()
    {
        foreach (Transform transform in targetSpawnpoints)
        {
            Instantiate(target, transform.position, transform.rotation);
        }
        //Get Targets after they spawn
        GetTargets();
    }

    public void GetTargets()
    {
        //Find all of the targets
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Target"))
        {
            //Get component
            MyTargetScript temp = fooObj.GetComponent<MyTargetScript>();

            //Add component to the list
            targets.Add(temp);
        }
    }

    public void StartTimer()
    {
        //Starts the timer coroutine with the game rather than on start
        gameTimer = FindObjectOfType<Timer>();
        winLoss.text = "";
        gameTimer.StartCoroutine("Countdown");
    }

    public void EndGameWin()
    {
        //Finds all of the targets and destroys them
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Target"))
        {
            //Test End Game Win
            Debug.Log("End Game Win");

            //Remove from the list and destroy all targets
            targets.Clear();
            Destroy(fooObj);

            //Stops timer and displays win text
            gameTimer.StopAllCoroutines();
            gameTimer.running = false;
            winLoss.text = ("You Win");
            Debug.Log("You Win");
        }
    }

    public void EndGameLose()
    {
        //Finds all of the targets
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Target"))
        {
            //Test End Game Lose
            Debug.Log("End Game Lose");

            //Remove from the list and destroy all targets
            targets.Clear();
            Destroy(fooObj);

            //Stops timer and displays loss text
            gameTimer.StopAllCoroutines();
            gameTimer.running = false;
            winLoss.text = ("You Lose");
            Debug.Log("You Lose");
        }
    }

    private bool IsEveryTargetHit()
    {
        //parse through the list of targets
        foreach (MyTargetScript target in targets)
        {
            //If any target isn't hit
            if (target.isHit == false)
            {
                return false;
            }
        }

        //if all the targets are hit
        return true;
    }
}
