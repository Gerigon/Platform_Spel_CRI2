﻿using System.Collections;
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

        if (Vector3.Distance(_owner.transform.position,GameManager.instance.player.transform.position)<1000)
        {
            _owner.movementController.MoveTo(GameManager.instance.player.transform.position);
        }
    }
    public override void EndState()
    {
        Debug.Log("Ending State");
    }
}
