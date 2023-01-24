using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFinish : BaseCameraSets
{
    public CameraFinish(CameraStruct settings, Transform target) : base(target) 
    {
        cameraSettings = settings;
    }
}
