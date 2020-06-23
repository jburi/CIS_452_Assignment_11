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
    /*
    //Game Prefabs
    public Target_Prefab target;
    public List<Transform> targetSpawnpoints;
    public Text winLoss;

    //Variables
    public List<MyTargetScript> targets;
    public Timer gameTimer;

    */
    private GameManager gm;
    private Timer timer;

    // Start is called before the first frame update
    void Start()
    {
        //gm = new GameManager(target, targetSpawnpoints, winLoss, targets, gameTimer);
        gm = FindObjectOfType<GameManager>();
        timer = FindObjectOfType<Timer>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet" && timer.running == false)
        {
            gm.StartGame();
        }
    }
}
