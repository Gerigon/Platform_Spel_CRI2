﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttackList {

    public static List<Attack> playerAttacks = new List<Attack>();

    static Attack basic_attack_001 = new Attack("Slash",
                                new AttackFrame(10),
                                new AttackFrame(30f, new Vector3(0.3f, 0, 0), new Vector3(0.5f, 0.5f, 0.5f),new Vector3(2,3,0),10));
    static Attack basic_attack_002 = new Attack("Hit-Slash",
                                new AttackFrame(4),
                                new AttackFrame(10f, new Vector3(0.5f, 0, 0), new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0, 4, 0), 5),
                                new AttackFrame(30f),
                                new AttackFrame(30f, new Vector3(0.5f, 0, 0), new Vector3(0.7f, 1, 0.5f), new Vector3(6, 0, 0), 10));
    static public void Start()
    {
        Debug.Log("I serve a lot of chickens and I'm innocent");
        playerAttacks.Add(basic_attack_001);
        playerAttacks.Add(basic_attack_002);
    }
}
