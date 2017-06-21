using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {


    public MovementController movementController;
	// Use this for initialization
	void Start () {
        movementController = new MovementController(this);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
