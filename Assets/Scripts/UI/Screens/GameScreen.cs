using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScreen : UIScreen
{
    protected override void Subscribe()
    {
        base.Subscribe();

        GlobalStateEvents.OnGlobalGameStateEnter += OnGameEnter;
        GlobalStateEvents.OnGlobalGameStateExit += OnGameExit;
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        GlobalStateEvents.OnGlobalGameStateEnter -= OnGameEnter;
        GlobalStateEvents.OnGlobalGameStateExit -= OnGameExit;
    }

    private void OnGameEnter()
    {
        this.gameObject.SetActive(true);
    }

    private void OnGameExit()
    {
        this.gameObject.SetActive(false);
    }
}