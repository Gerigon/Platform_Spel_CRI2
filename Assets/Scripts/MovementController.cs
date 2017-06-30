﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
      
    public Actor _owner;
    private bool grounded;
    private Rigidbody rigidBody;


	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(grounded);
    }

    public void Move(int dir, float speed)
    {
        switch (dir )
        {
            case 0:
                transform.Translate(new Vector3(0, 0, 0.6f) * _owner.speed, Space.World);
                break;
            case 1:
                transform.Translate(new Vector3(1, 0, 0) * _owner.speed, Space.World);
                _owner.combatController.flipFacing(1);
                break;
            case 2:
                 transform.Translate(new Vector3(0, 0, -0.6f) * _owner.speed, Space.World);
                break;
            case 3:
                transform.Translate(new Vector3(-1, 0, 0) * _owner.speed, Space.World);
                _owner.combatController.flipFacing(-1);
                break;
        }
        
    }
    public void Jump()
    {
        
        if (grounded)
        {
            Debug.Log(rigidBody.transform.name);
            rigidBody.velocity = new Vector3(0, 1*_owner.jumpPower, 0);
        }
    }

    public void ReceiveImpact(Vector3 impact)
    {
        
        rigidBody.velocity = impact;
        Debug.Log(rigidBody.velocity);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name=="Floor")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name == "Floor")
        {
            grounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "HitBox")
        {
            other.transform.parent.GetComponent<Actor>().health -= 10;
        }
    }
}
