using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class ToggleActionBase : ActionBase
{
    [ShowInInspector]
    [ReadOnly]
    private bool value;

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
