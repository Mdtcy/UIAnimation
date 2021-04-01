using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogAction : CustomAction
{
    public string LogContent;

    /// <inheritdoc />
    public override void Execute()
    {
        base.Execute();
        Debug.Log(LogContent);
    }
}
