using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CopyTextAnimation : CustomAction
{
    [SerializeField]
    private Text txtSource;

    [SerializeField]
    private Text txtTarget;

    [SerializeField]
    private float duration;

    [SerializeField]
    private float scaleSize;

    private void OnEnable()
    {
        ResetText();
    }

    /// <inheritdoc />
    public override void Execute()
    {
        base.Execute();
        txtTarget.text  = txtSource.text;
        txtTarget.color = new Color(txtTarget.color.r, txtTarget.color.g, txtTarget.color.b, 1);
        var sequence = DOTween.Sequence();
        sequence.Insert(0,txtTarget.DOFade(0, duration));
        sequence.Insert(0, txtTarget.transform.DOScale(scaleSize, duration));
        sequence.OnComplete(ResetText);
        sequence.Play();
    }

    private void ResetText()
    {
        txtTarget.color = new Color(txtTarget.color.r, txtTarget.color.g, txtTarget.color.b, 0);
        txtTarget.text  = string.Empty;
        txtTarget.transform.localScale = Vector3.one;
    }

}
