using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScreen : MonoBehaviour, IInitable
{
    public void Init()
    {
        Subscribe();
        this.gameObject.SetActive(false);
    }

    protected virtual void OnDestoy()
    {
        Unsubscribe();
    }

    protected virtual void Subscribe()
    {
        Events.OnResetGame += OnResetGame;
    }

    protected virtual void Unsubscribe()
    {
        Events.OnResetGame -= OnResetGame;
    }

    protected virtual void OnResetGame()
    {
        this.gameObject.SetActive(false);
    }
}