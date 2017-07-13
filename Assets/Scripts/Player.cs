using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor {

    

	// Use this for initialization
	protected override void Start () {
        base.Start();
        speed = 0.05f;
        jumpPower = 5;
        health = 7;
        combatController.attackList = AttackList.playerAttacks;
        combatController.hittable = 1 << 9;


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
        if (Input.GetKey(KeyCode.Space))
        {
            movementController.Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            combatController.Attack();
            animationController.setAnimValue("Attack");
        }
    }
}
