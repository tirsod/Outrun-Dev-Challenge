using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsUI : MonoBehaviour
{
    
    [SerializeField] private Button playButton;
    [SerializeField] private Button restartButton;
    
    void Start()
    {
        playButton.onClick.AddListener(Play);
        restartButton.onClick.AddListener(Play);
    }

    private void Play()
    {
        Game.Start();
        gameObject.SetActive(false);
    }
    
}
