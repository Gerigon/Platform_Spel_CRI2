using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{


    public InputManager inputManager;
    // Use this for initialization
    protected override void Start()
    {
        inputManager = gameObject.AddComponent<InputManager>();
        inputManager._owner = this;
        base.Start();
        speed = 0.5f;
        jumpPower = 5;
        health = 7;

    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
    }
}
