using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextParticleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject textParticle;
    [SerializeField] private GameObject particleContainer;

    private Pool textParticlePool;

    private void Awake()
    {
        textParticlePool = new Pool(textParticle, particleContainer);
    }

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
        PlayerPicker.OnItemTrow += ItemTrow;
    }

    private void Unsubscribe()
    {
        PlayerPicker.OnItemTrow -= ItemTrow;
    }

    private void ItemTrow(GameObject obj)
    {
        textParticlePool.GetFreeElement(particleContainer.transform.position).GetComponent<TextParticle>().Animate();
    }
}
