using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFrame
{

    public float duration;
    public Vector3 size;
    public Vector3 offset;
    public BoxCollider boxCollider;

    public AttackFrame(float Duration)
    {
        duration = Duration;
    }

    public AttackFrame(float Duration, Vector3 Offset, Vector3 Size)
    {
        duration = Duration;
        size = Size;
        offset = Offset;
    }
}
