using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AttackList {

    public static List<Attack> playerAttacks = new List<Attack>();

    static Attack basic_attack_001 = new Attack("Slash",
                                new AttackFrame(30),
                                new AttackFrame(30f, new Vector3(2, 0, 0), new Vector3(2, 2, 2)));
    static public void Start()
    {
        Debug.Log("I serve a lot of chickens and I'm innocent");
        playerAttacks.Add(basic_attack_001);
    }
}
