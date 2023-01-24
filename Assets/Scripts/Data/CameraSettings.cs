using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "settings", menuName = "Settings/Camera settings", order = 2)]
public class CameraSettings : ScriptableObject
{
    [Space]
    public CameraStruct menu;
    public CameraStruct game;
    public CameraStruct finish;
}