using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour {

    public Actor _owner;
    public State previousState;
    public State currentState;

	

    public void NewState(State state)
    {
        if (state != previousState || previousState == null)
        {
            if (currentState != null)
                currentState.EndState();
            previousState = currentState;
            currentState = state;
            currentState.EnterState(_owner);
        }
    }
    private void Update()
    {
        currentState.ExecuteState();
    }
}
