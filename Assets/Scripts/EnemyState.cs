using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : State {

    Actor _owner;
	// Use this for initialization
    

	public override void EnterState(Actor owner)
    {
        Debug.Log("Entering State");
        _owner = owner;

    }
    public override void ExecuteState()
    {
        Debug.Log("Executing State");
        if (Vector3.Distance(_owner.transform.position,GameManager.playerPos)<10)
        {
            _owner.movementController.MoveTo(GameManager.playerPos);
        }
    }
    public override void EndState()
    {
        Debug.Log("Ending State");
    }
}
