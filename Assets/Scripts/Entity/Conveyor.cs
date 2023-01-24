using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    public float speed;

    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += -transform.right * (speed * Time.deltaTime);
        rb.MovePosition(pos);
    }
}
