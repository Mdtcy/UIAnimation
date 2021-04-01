using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;

public class ToggleAction : CustomAction
{
    // todo 导入Odin后让他已读显示在inspector
    private bool             value;

    public  UnityEvent TrueEvent;
    public  UnityEvent FalseEvent;

    /// <inheritdoc />
    public override void Execute()
    {
        base.Execute();

        value = !value;
        if (value)
        {
            TrueEvent?.Invoke();
        }
        else
        {
            FalseEvent?.Invoke();
        }
    }
}
