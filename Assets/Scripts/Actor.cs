using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

    public MovementController movementController;
    public AnimationController animationController;
    public float speed;
    public float jumpPower;
				[HideInInspector]
    public int health;

    // Use this for initialization
    protected virtual void Start () {
        //animationController = new AnimationController(this);

        movementController = gameObject.AddComponent<MovementController>();
        movementController._owner = this;

        animationController = gameObject.AddComponent<AnimationController>();
        animationController._owner = this;
    }

    // Update is called once per frame
    protected virtual void Update () {
		
	}
}
