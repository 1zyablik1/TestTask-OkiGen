using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraGame : BaseCameraSets
{
    public CameraGame(CameraStruct settings, Transform target) : base(target) 
    {
        cameraSettings = settings;
    }
}
