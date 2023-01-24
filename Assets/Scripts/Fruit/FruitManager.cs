using System;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UIElements;

public class FruitManager : MonoBehaviour //rename
{
    [SerializeField] private FruitsList fruitsList;
    [SerializeField] private ProgressPanel progressPanel;
    [SerializeField] private MistakesPanel mistakesPanel;

    private List<NeededFruits> neededFruits;

    private void Awake()
    {
        neededFruits= new List<NeededFruits>();
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
        GlobalStateEvents.OnGlobalGameStateEnter += GameStateEnter;
        PlayerPicker.OnItemTrow += ItemThrow;
    }

    private void Unsubscribe()
    {
        GlobalStateEvents.OnGlobalGameStateEnter -= GameStateEnter;
        PlayerPicker.OnItemTrow -= ItemThrow;
    }

    private void GameStateEnter()
    {
        GenerateLevelData();
    }

    private void ItemThrow(GameObject pickedItem)
    {
        string name = pickedItem.name.Substring(0, pickedItem.name.Length - 7);
            
        for(int i = 0; i < neededFruits.Count; i++)
        {
            if (neededFruits[i].name == name)
            {
                NeededFruits neededFruit = new NeededFruits(name, neededFruits[i].count - 1);
                if(neededFruit.count == 0)
                {
                    neededFruits.RemoveAt(i);
                    CheckForWin();
                }
                else
                {
                    neededFruits[i] = neededFruit;
                }

                progressPanel.UpdateProgressBar(neededFruits);

                return;
            }
        }

        mistakesPanel.MistakedPicked();
    }

    private void CheckForWin()
    {
        if(neededFruits.Count == 0)
        {
            Events.OnLevelFinished(true);
            GlobalStateMachine.SetState<Finish>();
        }
    }

    private void GenerateLevelData()
    {
        neededFruits.Clear();

        GetRandomFruits();

        progressPanel.UpdateProgressBar(neededFruits);
    }

    private void GetRandomFruits()
    {
        for(int i = 0; i < 3; i++)
        {
            int num = GetRandomNum();
            string fruitName = GetRandomFruitName();

            NeededFruits neededFruit = new NeededFruits(fruitName, num);
            neededFruits.Add(neededFruit);
        }
    }

    private String GetRandomFruitName()
    {
        bool isDoubleName = true;
        string name = null;

        while (isDoubleName) 
        {
            int num = UnityEngine.Random.Range(0, fruitsList.fruits.Length);
            name = fruitsList.fruits[num].fruitType.ToString();
            
            isDoubleName = IsNameDouble(name);
        }
        return name;
    }

    private int GetRandomNum()
    {
        return UnityEngine.Random.Range(1, 5);
    }

    private bool IsNameDouble(string name)
    {
        foreach(var fruit in neededFruits)
        {
            if(fruit.name == name)
            {
                return true;
            }
        }
        return false;
    }
}
