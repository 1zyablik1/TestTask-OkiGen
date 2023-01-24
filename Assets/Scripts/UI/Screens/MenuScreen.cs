using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : UIScreen
{
    protected override void Subscribe()
    {
        base.Subscribe();

        GlobalStateEvents.OnGlobalMenuStateEnter += OnMenuEnter;
        GlobalStateEvents.OnGlobalMenuStateExit += OnMenuExit;
    }

    protected override void Unsubscribe()
    {
        base.Unsubscribe();

        GlobalStateEvents.OnGlobalMenuStateEnter -= OnMenuEnter;
        GlobalStateEvents.OnGlobalMenuStateExit -= OnMenuExit;
    }

    private void OnMenuEnter()
    {
        this.gameObject.SetActive(true);
    }

    private void OnMenuExit()
    {
        this.gameObject.SetActive(false);
    }
}