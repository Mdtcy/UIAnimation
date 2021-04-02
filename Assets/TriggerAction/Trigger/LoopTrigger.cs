using System.Collections;
using UnityEngine;

// todo 导入MEC后替换
public class LoopTrigger : MonoBehaviour
{
    // 是否无限循环
    [SerializeField]
    private bool infiniteLoop = true;

    // 循环次数 todo hide on can not infinite loop
    [SerializeField]
    private int loopTime;

    // 剩余循环次数
    private int remainLoopTime;

    // 间隔时间
    [SerializeField]
    private float interval;

    [SerializeField]
    private ActionBase actionBase;

    // 第一次触发前需要等待
    [SerializeField]
    private bool waitThenTrigger;

    private Coroutine loopCoroutine;

    private void OnEnable()
    {
        loopCoroutine = StartCoroutine(ILoop());
    }

    private void OnDisable()
    {
        StopCoroutine(loopCoroutine);
    }

    IEnumerator ILoop()
    {
        if (infiniteLoop)
        {
            if (waitThenTrigger)
            {
                yield return new WaitForSeconds(interval);
            }

            while (true)
            {
                actionBase.Execute();

                yield return new WaitForSeconds(interval);
            }
        }
        else
        {
            remainLoopTime = loopTime;

            if (waitThenTrigger)
            {
                yield return new WaitForSeconds(interval);
            }

            while (remainLoopTime > 0)
            {
                actionBase.Execute();
                yield return new WaitForSeconds(interval);
                remainLoopTime--;
            }
        }
    }
}
