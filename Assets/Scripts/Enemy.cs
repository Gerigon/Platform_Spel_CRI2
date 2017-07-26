using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actor {

    StateController stateController;

	// Use this for initialization
	protected override void Start () {
        base.Start();
        stateController = gameObject.AddComponent<StateController>();
        stateController._owner = this;
        stateController.NewState(new EnemyState());
        health = 3;
        speed = 0.05f;
        jumpPower = 5;

    }

    // Update is called once per frame
    protected override void Update() {
        base.Update();
		
	}

    public void OnDestroy()
    {
        Instantiate(GameManager.instance.enemyDrops[0], new Vector3(transform.position.x,.75f, transform.position.z), Quaternion.AngleAxis(90, Vector3.left));
    }

}
