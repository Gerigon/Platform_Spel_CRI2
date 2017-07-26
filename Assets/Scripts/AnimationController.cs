using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Actor _owner;
    public Animator animator;
    public string lastPlayedAnimation;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
       SetAnimationVar(GetAnimationVar("Walking") - 0.05f, "Walking");
    }


    public float GetAnimationVar(string paramater)
    {
        return animator.GetFloat(paramater);
    }

    public void SetAnimationVar(float value, string paramater)
    {
        animator.SetFloat(paramater, value);
    }
    public void SetAnimationVar( string paramater)
    {
        animator.SetTrigger(paramater);
    }


    public void SetLastPlayedAnimation (string animationName)
    {
        lastPlayedAnimation = animationName;
    }
}
