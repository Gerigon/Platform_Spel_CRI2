using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    List<KeyCode> inputQueue = new List<KeyCode>();
    public Actor _owner;

    Ray mouseRay;
    public Vector3 mousePosition;

    public void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _owner.movementController.Move(0, _owner.speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            _owner.movementController.Move(2, _owner.speed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            _owner.movementController.Move(3, _owner.speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            _owner.movementController.Move(1, _owner.speed);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            _owner.movementController.Jump();
        }
        if (Input.GetMouseButtonDown(0))
        {
            inputQueue.Add(KeyCode.Mouse0);
            
        }
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hit = Physics.RaycastAll(mouseRay, Mathf.Infinity, 1 << 10);
        for (int i = 0; i < hit.Length; i++)
        {
            Debug.Log(hit[i].transform.name);
            mousePosition = hit[i].point;
        }
        _owner.movementController.Rotate(mousePosition);
        Debug.Log(_owner.animationController.lastPlayedAnimation);
        if (inputQueue.Count > 0)
        {
            switch (inputQueue[0])
            {
                case KeyCode.Mouse0:
                    if (_owner.animationController.lastPlayedAnimation != "Attack1h1")
                        _owner.animationController.SetAnimationVar("Attack");
                    else
                        _owner.animationController.SetAnimationVar("Attack2");
                    inputQueue.RemoveAt(0);
                    break;
            }
        }
    }
}
