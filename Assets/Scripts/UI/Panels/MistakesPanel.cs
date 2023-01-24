using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class MistakesPanel : MonoBehaviour
{
    [SerializeField] private List<Image> imagesLives;
    [SerializeField] private Sprite mistakeSprite;
    [SerializeField] private Sprite nonMistakeSprite;

    private int lifesCount = 3; 

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDestroy()
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
        foreach(var image in imagesLives)
        {
            image.sprite = nonMistakeSprite;
        }

        lifesCount = 3;
    }

    public void MistakedPicked()
    {
        lifesCount -= 1;

        UpdateSprite(lifesCount);

        if(lifesCount == 0)
        {
            Events.OnLevelFinished?.Invoke(false);
            GlobalStateMachine.SetState<Finish>();
        }
    }

    private void UpdateSprite(int index)
    {
        imagesLives[index].sprite = mistakeSprite;
    }
}
