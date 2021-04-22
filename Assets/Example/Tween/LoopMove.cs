using DG.Tweening;
using UnityEngine;
using UnityExtensions;

/// <summary>
/// 循环移动
/// </summary>
public class LoopMove : MonoBehaviour
{
    // 起始位置
    [SerializeField]
    private RectTransform start;

    // 结束位置
    [SerializeField]
    private RectTransform end;

    // 开始时的位置在起始点和终点之间的比率
    [Range(0,1)]
    [SerializeField]
    private float startRatio;

    private RectTransform rectTransform;
    private Vector2       endAnchoredPos;
    private Vector2       startAnchoredPos;
    private Tween         moveTween;

    [SerializeField]
    private float speed = 5f;

    private void Awake()
    {
        rectTransform    = this.rectTransform();
        endAnchoredPos   = end.anchoredPosition;
        startAnchoredPos = start.anchoredPosition;
    }


    private void Start()
    {
        MoveToEnd();
    }

    // 从开始位置移动到终点
    private void MoveToEndFromStart()
    {
        rectTransform.anchoredPosition = start.anchoredPosition;
        MoveToEnd();
    }

    // 从当前位置移动到终点
    private void MoveToEnd()
    {
        float duration = Vector3.Distance(rectTransform.anchoredPosition, endAnchoredPos) / speed;

        moveTween.Kill();
        moveTween = rectTransform.DOAnchorPos(end.anchoredPosition, duration)
                                 .OnComplete(MoveToEndFromStart)
                                 .SetEase(Ease.Linear)
                                 .OnUpdate(OnUpdate);
    }

    // 清理协程
    private void OnDisable()
    {
        moveTween.Kill();
    }

    private void OnUpdate()
    {

    }

    // 设置起始位置
    private void OnValidate()
    {
        rectTransform    = this.rectTransform();
        endAnchoredPos   = end.anchoredPosition;
        startAnchoredPos = start.anchoredPosition;
        rectTransform.anchoredPosition = new Vector2(startRatio * (endAnchoredPos.x - startAnchoredPos.x),
                                                     startRatio * (endAnchoredPos.y - startAnchoredPos.y));
    }
}
