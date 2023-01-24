using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TextParticle : MonoBehaviour
{
    private Sequence sequence;

    public void Animate()
    {
        sequence = DOTween.Sequence();

        float newPosY = this.transform.position.y + 0.25f;

        sequence.Append(this.transform.DOMoveY(newPosY, 1f));
        sequence.AppendCallback(Disable);
    }

    private void Disable()
    {
        this.DOKill();
        this.gameObject.SetActive(false);
    }
}
