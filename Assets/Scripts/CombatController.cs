using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public Actor _owner;
    public BoxCollider attackBox;
    public Rigidbody Rigidbody;
    public Player player;
    public List<GameObject> hitActors = new List<GameObject>();



    // Use this for initialization
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Debug.Log("looking for weapon hitboxes");
        TraverseHierarchy(transform);
    }

    public void TraverseHierarchy(Transform root)
    {
        foreach (Transform child in root)
        {
            //Debug.Log(child.name);
            if (child.CompareTag("Weapon"))
            {
                attackBox = child.GetComponent<BoxCollider>();
                Debug.Log(attackBox);
                break;
            }
            TraverseHierarchy(child);
        }
    }

    public void ReceiveHit(Vector3 enemyPos, int Damage)
    {
        Debug.Log(_owner.name + " is gehit");
        Vector3 dir = new Vector3(transform.position.x - enemyPos.x, 1, transform.position.z - enemyPos.z).normalized;
        float force = 5;
        Rigidbody.AddForce(dir * force, ForceMode.Impulse);

        _owner.health -= Damage;
        _owner.animationController.SetAnimationVar("Hit");
        if (_owner.health <= 0)
        {
            Destroy(_owner.gameObject);
        }
    }


    public void PerformAttack()
    {
        attackBox.enabled = true;
        hitActors = new List<GameObject>();

    }

    public void EndAttack()
    {
        attackBox.enabled = false;
        hitActors = new List<GameObject>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!hitActors.Contains(other.gameObject))
        {
            hitActors.Add(other.gameObject);
            if (other.gameObject.tag == "Hitbox")
            {
                other.transform.GetComponent<Actor>().combatController.ReceiveHit(transform.position, 1);
            }
            else if (other.gameObject.tag == "Player")
            {
                other.transform.GetComponent<Actor>().combatController.ReceiveHit(transform.position, 1);
                GameManager.instance.gui_Health.TakeDamage(0);
            }
        }
    }

    public void NextComboInput(string next)
    {
        if (_owner.name == "Player")
        {
            player = (Player)_owner;
            if (next == "true")
            {
                player.inputManager.nextInput = true;
            }
            else if (next == "false")
            {
                player.inputManager.nextInput = false;
            }
        }
    }
    public void NextComboAttack()
    {
        if (_owner.name == "Player")
        {
            player = (Player)_owner;
            if (player.inputManager.inputQueue.Count > 0)
            {
                if (player.inputManager.inputQueue[0] == KeyCode.Mouse0)
                {
                    _owner.animationController.SetAnimationVar("Attack2");
                    player.inputManager.inputQueue.Clear();
                }
            }
        }
    }
}
