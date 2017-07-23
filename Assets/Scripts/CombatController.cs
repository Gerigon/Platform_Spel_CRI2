using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    public Actor _owner;
    public BoxCollider attackBox;
    public Rigidbody rigidbody;


    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
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

    public void ReceiveHit(Vector3 enemyPos)
    {
        Vector3 dir = new Vector3(transform.position.x - enemyPos.x, 5, transform.position.z - enemyPos.z).normalized;
        float force = 5;
        rigidbody.AddForce(dir * force, ForceMode.Impulse);
    }

    public void ReceiveImpact()
    {

    }

    public void PerformAttack()
    {
        attackBox.enabled = true;
    }
    public void EndAttack()
    {
        attackBox.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Hitbox")
        {
            other.transform.GetComponent<Actor>().combatController.ReceiveHit(transform.position);
        }
    }
}
