using System;
using System.Collections;
using UnityEngine;

public class PlayerPicker : MonoBehaviour
{
    private const string grabItemName = "GrabItem";
    [SerializeField] private Transform hand;
    [SerializeField] private Transform IKHandle;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Animator animator;

    private bool isCanToPeek = true;
    private bool isPicked = false;

    private GameObject pickedItem;
    private Collider colliderOfPicked;
    private Rigidbody rbOfPickedItem;

    public static Action<GameObject> OnItemTrow;

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
        PickingControl.OnPicking += OnPlayerPick;
    }

    private void Unsubscribe()
    {
        PickingControl.OnPicking -= OnPlayerPick;
    }

    private void OnPlayerPick(GameObject obj)
    {
        if (!isCanToPeek)
            return;

        animator.SetTrigger(grabItemName);
        isCanToPeek = false;
        pickedItem = obj;

        StartCoroutine(Picking());
    }

    public void AnimatorPicked()
    {
        isPicked = true;
    }

    private void Picked()
    {
        pickedItem.transform.SetParent(hand);

        UpdatePickedItemPhysics(true);
    }

    public void Throw()
    {
        pickedItem.transform.SetParent(null);

        UpdatePickedItemPhysics(false);

        OnItemTrow?.Invoke(pickedItem);

        isPicked= false;
        isCanToPeek = true;
    }

    private void UpdatePickedItemPhysics(bool enabling)
    {
        colliderOfPicked = pickedItem.GetComponent<Collider>();
        colliderOfPicked.isTrigger = enabling;
        rbOfPickedItem = pickedItem.GetComponent<Rigidbody>();
        rbOfPickedItem.isKinematic = enabling;
    }


    private IEnumerator Picking()
    {
        while (!isPicked)
        {
            IKHandle.transform.position = pickedItem.transform.position + offset;
            yield return null;
        }
        Picked();
    }

}
