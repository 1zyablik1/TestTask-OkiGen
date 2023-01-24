public class Game : IGlobalState
{
    public void Enter()
    {
        GlobalStateEvents.OnGlobalGameStateEnterInvoke();
    }

    public void Exit()
    {
        GlobalStateEvents.OnGlobalGameStateExitInvoke();
    }
}

