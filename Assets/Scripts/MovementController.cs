using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {

    private float speed = 0.05f;
    private Actor _owner;

    public MovementController (Actor owner)
    {
        owner.movementController = this;
        _owner = owner;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(new Vector3(0, 0, 0.6f)*speed, Space.World);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(new Vector3(0, 0, -0.6f) * speed, Space.World);
        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Translate(new Vector3(-1, 0, 0) * speed, Space.World);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Translate(new Vector3(1, 0, 0) * speed, Space.World);
        //}

    }

    public void Move(int dir, float speed)
    {
        switch (dir )
        {
            case 0:
                transform.Translate(new Vector3(0, 0, 0.6f) * speed, Space.World);
                break;
            case 1:
                transform.Translate(new Vector3(1, 0, 0) * speed, Space.World);
                break;
            case 2:
                 transform.Translate(new Vector3(0, 0, -0.6f) * speed, Space.World);
                break;
            case 3:
                transform.Translate(new Vector3(-1, 0, 0) * speed, Space.World);
                break;
        }
        
    }
}
