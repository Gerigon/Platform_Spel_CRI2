using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFrame
{

    public float duration;
    public Vector3 size;
    public Vector3 offset;
    public Vector3 knockBack;
    public int damage;

    public AttackFrame(float Duration)
    {
        duration = Duration;
    }

    public AttackFrame(float Duration, Vector3 Offset, Vector3 Size, Vector3 KnockBack, int Damage)
    {
        duration = Duration;
        size = Size;
        offset = Offset;
        knockBack = KnockBack;
        damage = Damage;
    }
}
