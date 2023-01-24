using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "fruitsList", menuName = "Data/fruits List", order = 1)]
public class FruitsList : ScriptableObject
{
    public Fruit[] fruits; 
}
