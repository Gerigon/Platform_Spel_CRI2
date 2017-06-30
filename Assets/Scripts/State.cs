﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    public virtual void EnterState(Actor owner)
    {
    }
    public virtual void ExecuteState(Actor owner)
    {
    }
    public virtual void EndState(Actor owner)
    {
    }
}