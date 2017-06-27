using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    string _name;
    public List<AttackFrame> attackFrames = new List<AttackFrame>();

    public Attack(string Name, AttackFrame frame)
    {
        _name = Name;
        attackFrames.Add(frame);
    }
    public Attack(string Name, AttackFrame frame, AttackFrame frame2)
    {
        _name = Name;
        attackFrames.Add(frame);
        attackFrames.Add(frame2);
    }
    public Attack(string Name, AttackFrame frame, AttackFrame frame2, AttackFrame frame3)
    {
        _name = Name;
        attackFrames.Add(frame);
        attackFrames.Add(frame2);
        attackFrames.Add(frame3);
    }
    public Attack(string Name, AttackFrame frame, AttackFrame frame2, AttackFrame frame3, AttackFrame frame4)
    {
        _name = Name;
        attackFrames.Add(frame);
        attackFrames.Add(frame2);
        attackFrames.Add(frame3);
        attackFrames.Add(frame4);
    }
}
