using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
      
    public Actor _owner;
    private bool grounded;
    private Rigidbody rigidBody;
    public bool isMoving;


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
        _owner.animationController.SetAnimationVar(1, "Walking");
        switch (dir )
        {
            case 0:
                transform.Translate(new Vector3(0, 0, 0.6f) * _owner.speed, Space.World);
                break;
            case 1:
                transform.Translate(new Vector3(1, 0, 0) * _owner.speed, Space.World);
                break;
            case 2:
                 transform.Translate(new Vector3(0, 0, -0.6f) * _owner.speed, Space.World);
                break;
            case 3:
                transform.Translate(new Vector3(-1, 0, 0) * _owner.speed, Space.World);
                break;
        }
        
    }

    public void MoveTo(Vector3 target)
    {
        float step = (_owner.speed * 10) * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
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
        if (collision.collider.name.Contains("Floor"))
        {
            grounded = true;
        }
        if (_owner.name == "Player" && collision.collider.gameObject.layer == 9)
        {
            Debug.Log("Collision Damage");
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        //Debug.Log(collision.collider.name);
        if (collision.collider.name.Contains("Floor"))
        {
            grounded = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "HitBox")
        {
            //other.transform.parent.GetComponent<Actor>().health -= 10;
        }
    }
}
