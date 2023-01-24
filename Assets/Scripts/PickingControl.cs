using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingControl : MonoBehaviour
{
    public static Action<GameObject> OnPicking;

    [SerializeField] private LayerMask layerMask;

    void Update()
    {
        if(GlobalStateMachine.IsState<Game>() && Input.GetMouseButtonDown(0))
        {
            ClickToPickUp();
        }
    }

    private void ClickToPickUp()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 10, layerMask))
        {
            if (hit.transform != null)
            {
                OnPicking?.Invoke(hit.transform.gameObject);
            }
        }
    }
}
