using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{

    [SerializeField] private GameObject _buttons;
    
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _restartButton;

    private void OnEnable()
    {
        Game.stopped += ShowRestart;
    }

    private void OnDisable()
    {
        Game.stopped -= ShowRestart;
    }

    private void ShowRestart()
    {
        _buttons.gameObject.SetActive(true);
        _playButton.SetActive(false);
        _restartButton.SetActive(true);
    }
}
