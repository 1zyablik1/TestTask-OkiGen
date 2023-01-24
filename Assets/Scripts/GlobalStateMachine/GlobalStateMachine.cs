using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GlobalStateMachine : MonoBehaviour
{
    private static List<IGlobalState> states;
    private static IGlobalState currentState;

    private void Awake()
    {
        states = new List<IGlobalState>()
        {
            new Menu(),
            new Game(),
            new Finish()
        };
    }

    private void Start()
    {
        SetState<Menu>();
    }

    public static bool IsState<T>() where T : IGlobalState
    {
        if(currentState is T)
        {
            return true;
        }

        return false;
    }

    public static void SetState<T>() where T : IGlobalState
    {
        IGlobalState newState = states.FirstOrDefault(s => s is T);

        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }
}

