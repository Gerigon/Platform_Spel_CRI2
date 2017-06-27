using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour {

    public bool attacking;
    public Actor _owner;
    List<AttackFrame> attackFrames;

    public CombatController()
    {
        
    }
    // Use this for initialization
    void Start ()
    {
        //Create movelist
        attackFrames = new List<AttackFrame>();
        //Move 1
        attackFrames.Add(new AttackFrame("Basic_Attack", 30f, new Vector3(2, 0, 0), new Vector3(2, 2, 2)));
        //Move 2
        //attackFrames.Add(new AttackFrame("Basic_Attack2", 4f, new Vector3(4, 4, 4)));

        for (int i = 0; i < attackFrames.Count; i++)
        {
            //Debug.Log("loop");
            
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void Attack()
    {
        if (!attacking)
        {
            attacking = true;
            StartCoroutine("Execute");
        }
    }

    IEnumerator Execute()
    {
								float attackDuration = attackFrames[0].duration;
								for (int j = 0; j < attackDuration; j ++)
								{
												RaycastHit[] boxCast;
												Debug.Log("dsfsd");
												boxCast = Physics.BoxCastAll(transform.position + attackFrames[0].offset, attackFrames[0].size, Vector3.right);

												for (int i = 0; i < boxCast.Length; i++)
												{
																Debug.Log("hit " + boxCast[i].collider.transform.name);
																if (boxCast[i].collider.transform.name == "HitBox" && boxCast[i].collider.gameObject.layer == LayerMask.NameToLayer("Enemy"))
																{
																				Debug.Log(boxCast[i].collider.transform.parent);
																				boxCast[i].collider.transform.parent.GetComponent<Actor>().health -= 10;
																}
												}
												yield return null;
								}

        attacking = false;

	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        //Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));

        if (attacking) {
												
            Gizmos.DrawCube(transform.position + attackFrames[0].offset, attackFrames[0].size);
        }
    }
}
