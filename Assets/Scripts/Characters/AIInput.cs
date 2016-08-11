using UnityEngine;
using System.Collections;

public class AIInput : BaseInput
{
    protected Transform target = null;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        if (target == null)
        {
            CheckForTarget();
        }
        else
        {
            PursueTarget();
        }
    }

    protected virtual void CheckForTarget()
    {

    }

    protected virtual void PursueTarget()
    {

    }

    public void SetTarget(Transform t)
    {
        target = t;
    }
}
