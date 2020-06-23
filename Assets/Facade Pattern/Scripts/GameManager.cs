/*
* Jake Buri
* GameManager.cs
* Assignment 11
* Handles all of the functions for the facade
*/

//GameManager.cs

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
    public Target_Prefab target;
    public List<Transform> targetSpawnpoints;
    public Text winLoss;

    //Variables
    public List<MyTargetScript> targets;
    public Timer gameTimer;

    /* Tried to make a constructor but can't with monobehavior
    public GameManager(Target_Prefab target, List<Transform> transforms, Text text, List<MyTargetScript> targetScripts, Timer timer)
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
        if (IsEveryTargetHit() == true)
        {
            EndGameWin();
        }
        else if (gameTimer.timeLeft == 0)
        {
            EndGameLose();
        }
    }

    //Facade function
    public void StartGame()
    {
        //Test Collision
        Debug.Log("Start Game");
        
        SpawnTargets();
        StartTimer();

        //Tried to run a coroutine since the new gamemanager wouldn't use void Update
        //this.StartCoroutine("EndTheGame"));
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
        gameTimer = FindObjectOfType<Timer>();
        winLoss.text = "";
        gameTimer.StartCoroutine("Countdown");
    }

    public void EndGameWin()
    {
        //Finds all of the targets and destroys them
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(fooObj);
            gameTimer.StopAllCoroutines();
            //StopAllCoroutines();
            winLoss.text = ("You Win");
            Debug.Log("You Win");
        }
    }

    public void EndGameLose()
    {
        //Finds all of the targets and destroys them
        foreach (GameObject fooObj in GameObject.FindGameObjectsWithTag("Target"))
        {
            Destroy(fooObj);
            gameTimer.StopAllCoroutines();
            //StopAllCoroutines();
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

    private IEnumerator EndTheGame()
    {
        if (IsEveryTargetHit() == true)
        {
            EndGameWin();
            yield return null;
        }
        else if (gameTimer.timeLeft == 0)
        {
            EndGameLose();
            yield return null;
        }
    }
}
