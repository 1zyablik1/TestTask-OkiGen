using System;

public class Events
{
    public static event Action OnResetGame;

    public static void ResetGame()
    {
        OnResetGame?.Invoke();
    }

    public static Action<bool> OnLevelFinished;
}
