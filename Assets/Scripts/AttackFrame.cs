using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFrame {


    public float duration;
    public BoxCollider boxCollider;

    public AttackFrame(float Duration, BoxCollider BoxCollider)
    {
        duration = Duration;
        boxCollider = BoxCollider;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
