using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    
    public Actor _owner;
    private bool grounded;
    private Rigidbody rigidBody;
    private List<BoxCollider> hitColliders;
    private List<BoxCollider> attackColliders;
    

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        hitColliders = new List<BoxCollider>();
        attackColliders = new List<BoxCollider>();

        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name.Contains("AttackBox"))
            {
                attackColliders.Add(transform.GetChild(i).GetComponent<BoxCollider>());
            }
            else if(transform.GetChild(i).name.Contains("HitBox"))
            {
                hitColliders.Add(transform.GetChild(i).GetComponent<BoxCollider>());
            }
        }
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
                break;
            case 2:
                 transform.Translate(new Vector3(0, 0, -0.6f) * _owner.speed, Space.World);
                break;
            case 3:
                transform.Translate(new Vector3(-1, 0, 0) * _owner.speed, Space.World);
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

    public void Attack()
    {
        for (int i = 0; i < attackColliders.Count; i++)
        {
            attackColliders[i].enabled = !attackColliders[i].enabled;
        }
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

    private void OnTriggerExit(Collider other)
    {

    }
}
