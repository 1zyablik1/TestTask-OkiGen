public class Menu : IGlobalState
{
    public void Enter()
    {
        GlobalStateEvents.OnGlobalMenuStateEnterInvoke();
    }

    public void Exit()
    {
        GlobalStateEvents.OnGlobalMenuStateExitInvoke();
    }

}

