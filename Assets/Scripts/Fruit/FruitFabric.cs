using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FruitFabric : MonoBehaviour
{
    [SerializeField] private FruitsList fruitsList;
    [SerializeField] private Transform poolContainer;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] protected float fruitTimeSpawnDelay;

    private Dictionary<FruitType, Pool>  fruitsPool;
    private bool isCanToSpawn = true;

    void Awake()
    {
        CreatePools();
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
        Events.OnResetGame += ResetGame;
    }

    private void Unsubscribe()
    {
        Events.OnResetGame -= ResetGame;
    }

    private void ResetGame()
    {
        foreach(var pool in fruitsPool)
        {
            pool.Value.DeactivatePool();
        }
    }

    private void CreatePools()
    {
        fruitsPool = new Dictionary<FruitType, Pool>();

        for (int i = 0; i < fruitsList.fruits.Length; i++)
        {

            GameObject gm = new GameObject(fruitsList.fruits[i].fruit.name + ".container");
            gm.transform.SetParent(poolContainer);

            Pool pool = new Pool(fruitsList.fruits[i].fruit, gm);
            fruitsPool.Add(fruitsList.fruits[i].fruitType, pool);
        }
    }

    protected void TryToSpawn()
    {
        if(GlobalStateMachine.IsState<Game>() && isCanToSpawn)
        {
            isCanToSpawn = false;

            GameObject spawnFruit = GetRandomFruitAndSpawn();

            StartCoroutine(SpawnigDelay());
        }
    }

    protected IEnumerator SpawnigDelay()
    {
        yield return new WaitForSeconds(fruitTimeSpawnDelay);

        isCanToSpawn = true;
    }

    private GameObject GetRandomFruitAndSpawn()
    {
        int indexOfFruit = UnityEngine.Random.Range(0, fruitsList.fruits.Length);

        return fruitsPool[fruitsList.fruits[indexOfFruit].fruitType].GetFreeElement(spawnPoint.position);
    }

    void Update()
    {
        TryToSpawn();
    }
}

