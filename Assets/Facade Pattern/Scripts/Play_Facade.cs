/*
* Jake Buri
* Play_Facade.cs
* Assignment 11
* Facade for the pattern
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play_Facade : MonoBehaviour
{
    //Variables
    private GameManager gm;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        //Failed constructor
        //gm = new GameManager(target, targetSpawnpoints, winLoss, targets, gameTimer);

        //Get GameManager and Timer
        gm = FindObjectOfType<GameManager>();
        timer = FindObjectOfType<Timer>();
    }

    //If this object is shot and the game is not running, the game will start
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet" && timer.running == false)
        {
            gm.StartGame();
        }
    }
}
