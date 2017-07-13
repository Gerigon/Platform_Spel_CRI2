using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Vector3 playerPos;
    public static GUI_Health gui_Health;
	// Use this for initialization
	void Start () {
        AttackList.Start();
        gui_Health = GetComponent<GUI_Health>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
