using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{


    public InputManager inputManager;
    // Use this for initialization
    protected override void Start()
    {
        inputManager = gameObject.AddComponent<InputManager>();
        inputManager._owner = this;
        base.Start();
        speed = 0.5f;
        jumpPower = 5;
        health = 7;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
<<<<<<< HEAD
        if (Input.GetKey(KeyCode.W))
        {
            movementController.Move(0, speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            movementController.Move(2, speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            movementController.Move(3, speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            movementController.Move(1, speed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            movementController.Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            animationController.SetAnimationVar("Attack");
            //combatController.PerformAttack();
        }
        RaycastHit[] hit = Physics.RaycastAll(mouseRay, Mathf.Infinity, 1 << 10);
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        for (int i = 0; i < hit.Length; i++)
        {
            Debug.Log(hit[i].transform.name);
            mousePosition = hit[i].point;
        }
        movementController.Rotate(mousePosition);
=======
        
>>>>>>> bc49db4548c53f2770d7fab690348a8b9115a2b2
    }
}
