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

    private void Start()
    {

    }

    public void Attack()
    {
        if (!attacking)
        {
            attacking = true;
            coroutine = Execute(attackList[0]);
            StartCoroutine(coroutine);
        }
    }

    public void ReceiveDamage(int value)
    {
        _owner.health -= value;
    }

    IEnumerator Execute(Attack attack)
    {
        for (int k = 0; k < attack.attackFrames.Count; k++)
        {
            float attackDuration = attack.attackFrames[k].duration;
            List<Actor> enemiesHit = new List<Actor>();
            for (int j = 0; j < attackDuration; j++)
            {
                RaycastHit[] boxCast;
                if (attack.attackFrames[k].size != Vector3.zero)
                {
                    boxCast = Physics.BoxCastAll(transform.position + attack.attackFrames[k].offset, attack.attackFrames[k].size, Vector3.right);
                    testOffset = attack.attackFrames[k].offset;
                    testSize = attack.attackFrames[k].size;
                    for (int i = 0; i < boxCast.Length; i++)
                    {
                        if (boxCast[i].collider.transform.name == "HitBox" && boxCast[i].collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                        {
                            Debug.Log(enemiesHit.Count);
                            if (!enemiesHit.Contains(boxCast[i].collider.transform.parent.GetComponent<Actor>()))
                            {
                                Debug.Log(boxCast[i].collider.transform.parent);
                                boxCast[i].collider.transform.parent.GetComponent<Actor>().movementController.ReceiveImpact(new Vector3(2, -1, 0));
                                enemiesHit.Add(boxCast[i].collider.transform.parent.GetComponent<Actor>());
                                boxCast[i].collider.transform.parent.GetComponent<CombatController>().ReceiveDamage(10);
                            }
                        }
                    }
                }
                yield return null;
            }
            enemiesHit.Clear();
            testOffset = Vector3.zero;
            testSize = Vector3.zero;
        }
        attacking = false;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        //Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));

        if (attacking)
        {

            Gizmos.DrawCube(transform.position + testOffset, testSize/2);
        }
    }
}
