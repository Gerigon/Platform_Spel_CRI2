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
        attackFrames.Add(new AttackFrame("Basic_Attack", 4f, new Vector3(2, 2, 2)));
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
        yield return new WaitForSeconds(attackFrames[0].duration);
        attacking = false;

        for (int i = 0; i < attackFrames[0].duration; i++) {
			
        }

	}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        //Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));

        if (attacking) {
            Gizmos.DrawCube(transform.position, attackFrames[0].size);
        }
    }
}
