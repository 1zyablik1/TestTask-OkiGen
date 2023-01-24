using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgressPanel : MonoBehaviour
{
    public List<TMP_Text> textes;

    public void UpdateProgressBar(List<NeededFruits> fruits)
    {
        ClearProgress();

        for(int i = 0; i < fruits.Count; i++)
        {
            textes[i].text = $"{fruits[i].name} : {fruits[i].count}";
        }
    }

    private void ClearProgress()
    {
        foreach(TMP_Text text in textes)
        {
            text.text = "";
        }
    }
}
