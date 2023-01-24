using UnityEngine;

public class UIInitializer : MonoBehaviour
{
    private void Awake()
    {
        var initScripts = GetComponentsInChildren<IInitable>(true);

        foreach (var scipt in initScripts)
        {
            scipt.Init();
        }
    }
}