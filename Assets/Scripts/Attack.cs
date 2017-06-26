using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {


    List<AttackFrame> attackFrames;

    public Attack()
    {

    }
    // Use this for initialization
    void Start ()
    {
        attackFrames = new List<AttackFrame>();
        attackFrames.Add(new AttackFrame(4f, new BoxCollider()));
        attackFrames[0].boxCollider.size = new Vector3(2, 2, 2);

        for (int i = 0; i < attackFrames.Count; i++)
        {
            Debug.Log("loop");
            StartCoroutine("Execute");
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    IEnumerator Execute()
    {
        for (float time = attackFrames[0].duration; time > 0; time -= Time.deltaTime)
        {
            Gizmos.DrawCube(transform.position, attackFrames[0].boxCollider.size);
        }
        yield return null;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5F);
        Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }
}
