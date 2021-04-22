using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityExtensions;

public class LoopMoveUseAnchor : MonoBehaviour
{
    [SerializeField]
    private float duration;

    [SerializeField]
    private Vector2 startAnchor;

    [SerializeField]
    private Vector2 endAnchor;

    private RectTransform rectTransform;
    private Sequence         curSequence;
    private void Awake()
    {
        rectTransform = this.rectTransform();
    }

    void Start()
    {
        MoveToEnd();
    }

    private void Restart()
    {
        rectTransform.anchorMin = startAnchor;
        rectTransform.anchorMax = startAnchor;
        curSequence.Kill();
        // MoveToEnd();
        curSequence = DOTween.Sequence();
        curSequence.Insert(0, rectTransform.DOAnchorMin(endAnchor, duration));
        curSequence.Insert(0, rectTransform.DOAnchorMax(endAnchor, duration));
        curSequence.OnComplete(Restart);

    }

    private void MoveToEnd()
    {
        float ratio    = (endAnchor.x - rectTransform.anchorMin.x) / (endAnchor.x - startAnchor.x);
        curSequence = DOTween.Sequence();
        curSequence.Insert(0, rectTransform.DOAnchorMin(endAnchor, ratio * duration));
        curSequence.Insert(0, rectTransform.DOAnchorMax(endAnchor, ratio * duration));
        curSequence.OnComplete(Restart);
    }

    private void OnDisable()
    {
        curSequence.Kill();
    }
}
