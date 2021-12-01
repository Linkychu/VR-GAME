using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChaseState : CubesState
{

    public CubeAttackState attackState;
    public bool isInAttackRange;
    public override CubesState RunCurrentState()
    {
        if (isInAttackRange)
        {
            return attackState;
        }
        else
        {
            return this;
        }
        
    }
}
