using System.Collections;
using UnityEngine;

// todo 导入MEC后替换
public class LoopTrigger : MonoBehaviour
{
    // 间隔时间
    [SerializeField]
    private float interval;

    [SerializeField]
    private CustomAction action;

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
        if (waitThenTrigger)
        {
            yield return new WaitForSeconds(interval);
        }

        while (true)
        {
            action.Execute();
            yield return new WaitForSeconds(interval);
        }
    }
}
