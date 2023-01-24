using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalStateEvents
{
    public static event Action OnGlobalMenuStateEnter;
    public static event Action OnGlobalMenuStateExit;

    public static event Action OnGlobalGameStateEnter;
    public static event Action OnGlobalGameStateExit;

    public static event Action OnGlobalFinishStateEnter;
    public static event Action OnGlobalFinishStateExit;

    public static void OnGlobalMenuStateEnterInvoke()
    {
        OnGlobalMenuStateEnter?.Invoke();
    }

    public static void OnGlobalMenuStateExitInvoke()
    {
        OnGlobalMenuStateExit?.Invoke();
    }

    public static void OnGlobalGameStateEnterInvoke()
    {
        OnGlobalGameStateEnter?.Invoke();
    }

    public static void OnGlobalGameStateExitInvoke()
    {
        OnGlobalGameStateExit?.Invoke();
    }

    public static void OnGlobalFinishStateEnterInvoke()
    {
        OnGlobalFinishStateEnter?.Invoke();
    }

    public static void OnGlobalFinishStateExitInvoke()
    {
        OnGlobalFinishStateExit?.Invoke();
    }

}
