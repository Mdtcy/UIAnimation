using UnityEngine;

public class ActionBase : MonoBehaviour
{
    public virtual void Execute()
    {
    }

    public virtual void Stop()
    {
        Debug.LogError("Do not override Stop!");
    }
}
