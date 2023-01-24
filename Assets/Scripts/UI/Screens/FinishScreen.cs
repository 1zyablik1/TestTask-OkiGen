using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishScreen : UIScreen
{
    protected override void Subscribe()
    {
        base.Subscribe();

        GlobalStateEvents.OnGlobalFinishStateEnter += OnFinishEnter;
        GlobalStateEvents.OnGlobalFinishStateExit += OnFinishExit;
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        GlobalStateEvents.OnGlobalFinishStateEnter -= OnFinishEnter;
        GlobalStateEvents.OnGlobalFinishStateExit -= OnFinishExit;
    }

    private void OnFinishEnter()
    {
        this.gameObject.SetActive(true);
    }

    private void OnFinishExit()
    {
        this.gameObject.SetActive(false);
    }
}