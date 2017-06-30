using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    Actor _owner;
    State previousState;
    State currentState;

	

    void NewState(State state)
    {
        if (state != previousState)
        {
            if (currentState != null)
                currentState.EndState(_owner);
            previousState = currentState;
            currentState = state;
            currentState.EnterState(_owner);
        }
    }
    private void Update()
    {
        currentState.ExecuteState(_owner);
    }
}
