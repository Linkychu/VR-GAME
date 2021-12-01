using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesStateManager : MonoBehaviour
{
    private CubesState currentState;
    // Update is called once per frame
    void Update()
    {
        
    }

    private void RunStateMachine()
    {
        //? means not null.
        CubesState nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
        
        
        
    }

    private void SwitchToTheNextState(CubesState nextState)
    {
        currentState = nextState;
    }
    
}
