using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI bestText;

    void Start()
    {
        bestText.text = Game.GetBest();
    }
    
    void Update()
    {
        goldText.text = GameVariables.gold.ToString();
        
        bestText.text = GameVariables.best.ToString();
    }
}
