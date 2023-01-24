using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        GlobalStateMachine.SetState<Game>();
    }
}
