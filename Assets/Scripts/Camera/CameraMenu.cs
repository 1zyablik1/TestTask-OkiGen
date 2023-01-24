using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : BaseCameraSets
{
    public CameraMenu(CameraStruct settings, Transform target) : base(target) 
    {
        cameraSettings = settings;
    }
}
