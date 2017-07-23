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

    public string getCurrentAnimation()
    {
        float bestWeight = -1;
        string playing = "";
        foreach (AnimationState state in GetComponent<Animation>())
        {
            Debug.Log(state.name);
            if (state.enabled && state.weight > bestWeight)
            {
                playing = state.name;
                bestWeight = state.weight;
            }
        }
        return playing;
    }

    public void SetLastPlayedAnimation (string animationName)
    {
        Debug.Log(animationName);
        lastPlayedAnimation = animationName;
    }
}
