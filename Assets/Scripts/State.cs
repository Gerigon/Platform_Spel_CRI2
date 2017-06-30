using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {


    public virtual void EnterState(Actor owner)
    {
    }
    public virtual void ExecuteState()
    {
    }
    public virtual void EndState()
    {
    }
}
