using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Action started = () => { };
    public static Action stopped = () => { };
    
    public static void End()
    {
        stopped.Invoke();
        GameVariables.isDead = true;
        GameVariables.speed = 0f;
    }
    
    public static void Start()
    {
        started.Invoke();
        GameVariables.isDead = false;
        GameVariables.speed = 25f;
        GameVariables.gold = 0;
    }

    public static void GetGold()
    {
        GameVariables.gold += 1;

        if (GameVariables.gold > GameVariables.best)
        {
            GameVariables.best = GameVariables.gold;
            PlayerPrefs.SetInt("best", GameVariables.gold);
        }
    }

    public static string GetBest()
    {
        return PlayerPrefs.GetInt("best", GameVariables.gold).ToString();
    }
    
}
