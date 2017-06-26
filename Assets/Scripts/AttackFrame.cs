using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFrame {

    public string name;
    public float duration;
    public Vector3 size;
    public BoxCollider boxCollider;

    public AttackFrame(string Name, float Duration, Vector3 Size)
    {
        name = Name;
        duration = Duration;
        size = Size;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
