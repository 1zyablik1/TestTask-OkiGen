using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Vector3 rotationOnMenu;

    private Sequence sequence;

    private void Awake()
    {
        this.transform.rotation = Quaternion.Euler(rotationOnMenu);
        ChangeHandLayerWeight(0);
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
        Events.OnLevelFinished += LevelFinished;
        GlobalStateEvents.OnGlobalGameStateEnter += GlobalGameStateEnter;
        GlobalStateEvents.OnGlobalFinishStateEnter += GlobalFinishStateEnter;
    }

    private void Unsubscribe()
    {
        Events.OnResetGame -= ResetGame;
        Events.OnLevelFinished -= LevelFinished;
        GlobalStateEvents.OnGlobalGameStateEnter -= GlobalGameStateEnter;
        GlobalStateEvents.OnGlobalFinishStateEnter -= GlobalFinishStateEnter;
    }

    private void ResetGame()
    {
        this.transform.rotation = Quaternion.Euler(rotationOnMenu);
        ChangeHandLayerWeight(0);
        animator.SetTrigger("Reset");
    }

    private void LevelFinished(bool isLevelWin)
    {
        ChangeHandLayerWeightWithTime(0, 0, 1);

        if (isLevelWin)
            animator.SetTrigger("WinDance");
        else
            animator.SetTrigger("LoseCrying");
    }

    private void GlobalGameStateEnter()
    {
        sequence = DOTween.Sequence();

        sequence.Append(this.transform.DOLocalRotate(Vector3.zero, 1));

        ChangeHandLayerWeightWithTime(1, 1, 1);
    }

    private void GlobalFinishStateEnter()
    {
        sequence = DOTween.Sequence();

        sequence.Append(this.transform.DOLocalRotate(rotationOnMenu, 1));

        //ChangeHandLayerWeightWithTime(0, 1);
    }

    private void ChangeHandLayerWeightWithTime(float end, float target, float time)
    {
        StartCoroutine(ChangingWeight(end, target, time));
    }

    private void ChangeHandLayerWeight(float weight)
    {
        animator.SetLayerWeight(1, weight);
    }

    private IEnumerator ChangingWeight(float end, float target, float time)
    {
        while (animator.GetLayerWeight(1) != end)
        {
            animator.SetLayerWeight(1, Mathf.MoveTowards(animator.GetLayerWeight(1), target, time * Time.deltaTime));
            yield return null;

        }
    }
}
