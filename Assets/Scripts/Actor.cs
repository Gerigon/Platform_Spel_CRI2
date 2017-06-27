using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actor : MonoBehaviour {

    public AnimationController animationController;
    public MovementController movementController;
    public CombatController combatController;
    public float speed;
    public float jumpPower;
    public int health = 100;

    // Use this for initialization
    protected virtual void Start () {
        //animationController = new AnimationController(this);

        animationController = gameObject.AddComponent<AnimationController>();
        animationController._owner = this;

        movementController = gameObject.AddComponent<MovementController>();
        movementController._owner = this;

        combatController = gameObject.AddComponent<CombatController>();
        combatController._owner = this;
    }

    // Update is called once per frame
    protected virtual void Update () {
		
	}
}
