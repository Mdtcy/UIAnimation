using UnityEngine.Events;

/// <summary>
/// 包装其他脚本中的接口作为一个Action
/// </summary>
public class ActionBaseWrapper : ActionBase
{
    public UnityEvent EvtAction;

    /// <inheritdoc />
    public override void Execute()
    {
        base.Execute();
        EvtAction?.Invoke();
    }
}
