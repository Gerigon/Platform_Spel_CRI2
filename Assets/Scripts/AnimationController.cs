using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {

    public Actor _owner;
    Animator anim;
    SpriteRenderer spriteRenderer;


    // Use this for initialization
    void Start () {
        spriteRenderer = _owner.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (anim.GetBool("Flip"))
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
	}

    public void setAnimValue(bool value)
    {
        anim.SetBool("Flip", value);
    }
}
