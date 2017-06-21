using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

    public AnimationController animationController;
    public MovementController movementController;
	
    // Use this for initialization
	protected virtual void Start () {
        animationController = gameObject.AddComponent<AnimationController>();
        animationController._owner = this;
        movementController = gameObject.AddComponent<MovementController>();
		
	}

    // Update is called once per frame
    protected virtual void Update () {
		
	}
}
