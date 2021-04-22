using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 上下滚动的Text
/// </summary>
public class UpDownText : MonoBehaviour
{
    // 当前可见的text
    [SerializeField]
    private Text txtVisible;

    // 当前不可见的text, 例如要显示的下一个text
    [SerializeField]
    private Text txtInvisible;

    // text上方的位置
    [SerializeField]
    private Vector2 anchorUp;

    // 正中间，text显示的位置
    [SerializeField]
    private Vector2 anchorMiddle;

    // text下方的位置
    [SerializeField]
    private Vector2 anchorDown;

    // text滚动切换的时间
    [SerializeField]
    private float duration;

    // 切换时的动画曲线
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
