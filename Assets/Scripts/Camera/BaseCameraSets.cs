using UnityEngine;
using DG.Tweening;
public class BaseCameraSets
{
    protected Transform target;
    protected CameraStruct cameraSettings;

    public BaseCameraSets()
    {
    }

    public BaseCameraSets(Transform transform)
    {
        target = transform;
    }

    public virtual void ChangePositon()
    {
        target.DOLocalRotate(cameraSettings.rotation, cameraSettings.time);
        target.DOLocalMove(cameraSettings.position, cameraSettings.time);
    }
}
