using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {


    public MovementController movementController;
	
    // Use this for initialization
	protected virtual void Start () {
        movementController = gameObject.AddComponent<MovementController>();
        Debug.Log(movementController);
		
	}

    // Update is called once per frame
    protected virtual void Update () {
		
	}
}
