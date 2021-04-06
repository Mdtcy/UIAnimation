using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 上下滚动的Text
/// </summary>
public class UpDownText : MonoBehaviour
{
    [SerializeField]
    private Text txtVisible;

    [SerializeField]
    private Text txtInvisible;

    [SerializeField]
    private Vector2 anchorUp;

    [SerializeField]
    private Vector2 anchorMiddle;

    [SerializeField]
    private Vector2 anchorDown;

    [SerializeField]
    private float duration;

    [SerializeField]
    private Ease ease;

    /// <summary>
    ///  初始化
    /// </summary>
    /// <param name="str"></param>
    public void Setup(string str)
    {
        txtVisible.text = str;
    }

    [Button]
    /// <summary>
    /// 向上滚动
    /// </summary>
    /// <param name="str"></param>
    public void MoveUp(string str)
    {
        txtInvisible.text                    = str;
        txtInvisible.rectTransform.anchorMin = anchorDown;
        txtInvisible.rectTransform.anchorMax = anchorDown;

        var sequence = DOTween.Sequence();
        sequence.Insert(0, txtInvisible.rectTransform.DOAnchorMin(anchorMiddle, duration));
        sequence.Insert(0, txtInvisible.rectTransform.DOAnchorMax(anchorMiddle, duration));

        sequence.Insert(0, txtVisible.rectTransform.DOAnchorMin(anchorUp, duration));
        sequence.Insert(0, txtVisible.rectTransform.DOAnchorMax(anchorUp, duration));

        sequence.OnComplete(OnMoveComplete);
        sequence.SetEase(ease);
    }

    [Button]

    /// <summary>
    /// 向下滚动
    /// </summary>
    /// <param name="str"></param>
    public void MoveDown(string str)
    {
        txtInvisible.text                    = str;
        txtInvisible.rectTransform.anchorMin = anchorUp;
        txtInvisible.rectTransform.anchorMax = anchorUp;

        var sequence = DOTween.Sequence();
        sequence.Insert(0, txtInvisible.rectTransform.DOAnchorMin(anchorMiddle, duration));
        sequence.Insert(0, txtInvisible.rectTransform.DOAnchorMax(anchorMiddle, duration));

        sequence.Insert(0, txtVisible.rectTransform.DOAnchorMin(anchorDown, duration));
        sequence.Insert(0, txtVisible.rectTransform.DOAnchorMax(anchorDown, duration));

        sequence.OnComplete(OnMoveComplete);
        sequence.SetEase(ease);
    }

    /// <summary>
    /// 设置滚动的时间
    /// </summary>
    /// <param name="value"></param>
    public void SetDuration(float value)
    {
        duration = value;
    }

    // 滚动结束后可见和不可见的引用对调
    private void OnMoveComplete()
    {
        var tmpText = txtVisible;
        txtVisible   = txtInvisible;
        txtInvisible = tmpText;
    }

}
