using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public List<KeyCode> inputQueue = new List<KeyCode>();
    public Actor _owner;
    public bool nextInput;

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
            if (nextInput)
            {
                inputQueue.Add(KeyCode.Mouse0);
            }
            else
            {
                _owner.animationController.SetAnimationVar("Attack");
            }

        }
        mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hit = Physics.RaycastAll(mouseRay, Mathf.Infinity, 1 << 10);
        for (int i = 0; i < hit.Length; i++)
        {
            mousePosition = hit[i].point;
        }
        _owner.movementController.Rotate(mousePosition);

    }

    
}
