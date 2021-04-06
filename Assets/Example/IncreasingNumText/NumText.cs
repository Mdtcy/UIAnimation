using System;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 会增长的数字，仅支持两位数，如果大于两位数，则显示99,需要考虑快速点击时的情况，所以将时间设置为0.2f
/// </summary>
public class NumText : MonoBehaviour
{
    // 第一位数字
    [SerializeField]
    private UpDownText upDownTextOne;

    // 第二位数字
    [SerializeField]
    private UpDownText upDownTextTwo;

    [SerializeField]
    private float duration;

    // 当前对应的数字
    private int curNum;


    /// <summary>
    /// 初始化
    /// </summary>
    /// <param name="num"></param>
    [Button]
    public void Setup(int num)
    {
        if (num < 0 || num > 99)
        {
            Debug.LogError("[IncreasingNumText] 仅支持0-99以内的数字");
            return;
        }

        curNum = num;
        // 初始化十位数的数字，如果为0则不显示
        int tenNum = num / 10;
        int oneNum = num % 10;
        if (tenNum == 0)
        {
            upDownTextOne.Setup(oneNum.ToString());
            upDownTextTwo.Setup(String.Empty);

        }
        else
        {
            upDownTextOne.Setup(tenNum.ToString());
            upDownTextTwo.Setup(oneNum.ToString());
        }

        upDownTextOne.SetDuration(duration);
        upDownTextTwo.SetDuration(duration);
    }

    [Button]
    public void ChangeNumber(int num)
    {
        if (num < 0 || num > 99)
        {
            Debug.LogError("[IncreasingNumText] 仅支持0-99以内的数字");
            return;
        }

        if (curNum > num)
        {
            Minus(num);
        }
        else if(curNum < num)
        {
            Add(num);
        }
    }

    [Button]
    public void Test()
    {
        if (curNum % 2==0)
        {
            ChangeNumber(curNum-1);
        }
        else
        {
            ChangeNumber(curNum+1);
        }
    }

    private void Add(int num)
    {
        // 一位数
        if (curNum < 10 && num < 10)
        {
            upDownTextOne.MoveUp(OnesPlace(num).ToString());
        }
        // 两位数
        else if(curNum >= 10 && num >= 10)
        {
            int tenCur = TensPlace(curNum);
            int oneCur = OnesPlace(curNum);
            int tenNum = TensPlace(num);
            int oneNum = OnesPlace(num);

            if (tenCur != tenNum)
            {
                upDownTextOne.MoveUp(tenNum.ToString());
            }

            if (oneCur != oneNum)
            {
                upDownTextTwo.MoveUp(oneNum.ToString());
            }
        }
        // 一位数变为两位数
        else if(curNum < 10 && num >= 10)
        {
            upDownTextOne.MoveUp(TensPlace(num).ToString());
            upDownTextTwo.MoveUp(OnesPlace(num).ToString());
        }

        curNum = num;
    }

    private void Minus(int num)
    {
        // 两位数变为一位数 eg. 10->9
        if (curNum >= 10 && num < 10)
        {
            upDownTextOne.MoveDown(OnesPlace(num).ToString());
            upDownTextTwo.MoveDown(String.Empty);
        }
        // 两位数
        else if(curNum >= 10 && num >= 10)
        {
            int tenCur = TensPlace(curNum);
            int oneCur = OnesPlace(curNum);
            int tenNum = TensPlace(num);
            int oneNum = OnesPlace(num);

            if (tenCur != tenNum)
            {
                upDownTextOne.MoveDown(TensPlace(num).ToString());
            }

            if (oneCur != oneNum)
            {
                upDownTextTwo.MoveDown(OnesPlace(num).ToString());
            }

        }
        // 一位数
        else if(curNum < 10 && num < 10)
        {
            upDownTextOne.MoveDown(OnesPlace(num).ToString());
        }

        curNum = num;

    }

    // 返回一个数的十位数
    private int TensPlace(int num)
    {
        if (num < 0 || num > 99)
        {
            Debug.LogError("[IncreasingNumText] 仅支持0-99以内的数字");
        }

        return num / 10;
    }

    // 返回一个数的个位数
    private int OnesPlace(int num)
    {
        if (num < 0 || num > 99)
        {
            Debug.LogError("[IncreasingNumText] 仅支持0-99以内的数字");
        }

        return num % 10;
    }

}
