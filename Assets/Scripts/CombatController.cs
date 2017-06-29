using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{

    public bool attacking;
    public Actor _owner;
    public List<Attack> attackList;
    private Vector3 testOffset;
    private Vector3 testSize;
    private IEnumerator coroutine;
    public BoxCollider attackBox;
    public int hittable;
    public bool facingRight = true;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "AttackBox")
            {
                attackBox = transform.GetChild(i).GetComponent<BoxCollider>();
                Debug.Log(attackBox);
            }
        }
    }

    public void Attack()
    {
        if (!attacking)
        {
            attacking = true;
            coroutine = Execute(attackList[1]);
            StartCoroutine(coroutine);
        }
    }

    public void ReceiveDamage(int value)
    {
        _owner.health -= value;
    }

    public void flipFacing()
    {
        facingRight = !facingRight;
    }

    /// <summary>
    /// Executes an attack consisting of 1 or multiple attack frames
    /// attackFrames are stored in an attack
    /// </summary>
    /// <param name="attack"></param>
    /// <returns></returns>
    IEnumerator Execute(Attack attack)
    {
        for (int k = 0; k < attack.attackFrames.Count; k++)
        {
            float attackDuration = attack.attackFrames[k].duration;
            List<Actor> enemiesHit = new List<Actor>();
            for (int j = 0; j < attackDuration; j++)
            {
                if (attack.attackFrames[k].size != Vector3.zero)
                {
                    Collider[] cols;
                    attackBox.transform.position = transform.position + attack.attackFrames[k].offset;
                    attackBox.size = attack.attackFrames[k].size;
                    cols = Physics.OverlapBox(attackBox.bounds.center, attackBox.bounds.extents, attackBox.transform.rotation, hittable);
                    foreach (Collider c in cols)
                    {
                        if (c.transform.name == "HitBox" && !enemiesHit.Contains(c.transform.parent.GetComponent<Actor>()))
                        {
                            c.transform.parent.GetComponent<Actor>().movementController.ReceiveImpact(attack.attackFrames[k].knockBack);
                            c.transform.parent.GetComponent<CombatController>().ReceiveDamage(attack.attackFrames[k].damage);
                            enemiesHit.Add(c.transform.parent.GetComponent<Actor>());
                        }
                    }
                }
                yield return null;
            }
            enemiesHit.Clear();
        }
        attacking = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        //Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));

        if (attacking)
        {

            Gizmos.DrawCube(transform.position + testOffset, testSize / 2);
        }
    }
}
