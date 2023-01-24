public class Finish : IGlobalState
{
    public void Enter()
    {
        GlobalStateEvents.OnGlobalFinishStateEnterInvoke();
    }

    public void Exit()
    {
        GlobalStateEvents.OnGlobalFinishStateExitInvoke();
        Events.ResetGame();
    }
}

