using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private CameraSettings cameraSettings;
    protected BaseCameraSets cameraSets;

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        Events.OnResetGame += ResetGame;

        GlobalStateEvents.OnGlobalMenuStateEnter += GlobalMenuStateEnter;
        GlobalStateEvents.OnGlobalGameStateEnter += GlobalGameStateEnter;
        GlobalStateEvents.OnGlobalFinishStateEnter += GlobalFinishStateEnter;
    }

    private void Unsubscribe()
    {
        Events.OnResetGame -= ResetGame;

        GlobalStateEvents.OnGlobalMenuStateEnter -= GlobalMenuStateEnter;
        GlobalStateEvents.OnGlobalGameStateEnter -= GlobalGameStateEnter;
        GlobalStateEvents.OnGlobalFinishStateEnter -= GlobalFinishStateEnter;
    }

    private void ResetGame()
    {
        GlobalMenuStateEnter();
    }

    private void GlobalMenuStateEnter()
    {
        cameraSets = new CameraMenu(cameraSettings.menu, this.transform);
        cameraSets.ChangePositon();
    }

    private void GlobalGameStateEnter()
    {

        cameraSets = new CameraGame(cameraSettings.game, this.transform);
        cameraSets.ChangePositon();
    }

    private void GlobalFinishStateEnter()
    {

        cameraSets = new CameraFinish(cameraSettings.finish, this.transform);
        cameraSets.ChangePositon();
    }
}
