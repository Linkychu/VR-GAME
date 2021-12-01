using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeIdleState : CubesState
{
    public CubeChaseState chaseState;
    public bool canSeeThePlayer;
    public LayerMask player;
    public override CubesState RunCurrentState()
    {
        if (Physics.CheckSphere(transform.position, 6, player))
        {
            return chaseState;
        }
        else
        {
            return this;
        }
        
        
    }
}
