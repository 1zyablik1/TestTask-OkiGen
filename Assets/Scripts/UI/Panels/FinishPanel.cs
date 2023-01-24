using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishPanel : MonoBehaviour
{

    private const string winText = "WIN!";
    private const string loseText = "LOSE";

    private const string winButtonText = "NEXT";
    private const string loseButtonText = "RESTART";

    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text textButton;

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Events.OnLevelFinished += LevelFinished;
    }

    private void Unsubscribe()
    {
        Events.OnLevelFinished -= LevelFinished;
    }

    private void LevelFinished(bool isLevelWin)
    {
        if (isLevelWin)
            LevelWin();
        else
            LevelLose();
    }

    private void LevelWin()
    {
        text.text = winText;
        textButton.text = winButtonText;
    }

    private void LevelLose()
    {
        text.text = loseText;
        textButton.text = loseButtonText;
    }

    public void ButtonClicked()
    {
        GlobalStateMachine.SetState<Menu>();
    }
}
