using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor {

    float speed =0.05f;

	// Use this for initialization
	protected override void Start () {
        base.Start();
	}

    // Update is called once per frame
    protected override void Update () {
        base.Update();
        if (Input.GetKey(KeyCode.W))
        {
            movementController.Move(0,speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementController.Move(2, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementController.Move(3, speed);
            animationController.setAnimValue(true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementController.Move(1, speed);
            animationController.setAnimValue(false);
        }
    }
}
