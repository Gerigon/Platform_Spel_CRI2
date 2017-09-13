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
    public bool inCombat;
    public bool combatTimerRunning;
    private Coroutine combatTimer;


    // Use this for initialization
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Debug.Log("looking for weapon hitboxes");
        TraverseHierarchy(transform);
    }
    private void Update()
    {
        if (inCombat)
            _owner.poise += 0.01f;
        else
            _owner.poise += 0.1f;
        _owner.poise = Mathf.Clamp(_owner.poise, -5, _owner.maxPoise);
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

    public void ReceiveHit(Vector3 enemyPos, int Damage, int poiseDamage)
    {
        inCombat = true;
        if (combatTimer != null)
            StopCoroutine(combatTimer);
        combatTimer = StartCoroutine(CombatTimer());
        
        
        Vector3 dir = new Vector3(transform.position.x - enemyPos.x, 1, transform.position.z - enemyPos.z).normalized;
        float force = 5;
        Rigidbody.AddForce(dir * force, ForceMode.Impulse);

        _owner.health -= Damage;
        _owner.poise -= poiseDamage;
        if (_owner.poise <= 0)
        {
            _owner.animationController.SetAnimationVar("Hit");
        }
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
            
            if (other.gameObject.tag == "Hitbox")
            {
                Debug.Log(other.name);
                inCombat = true;
                if (combatTimer != null)
                    StopCoroutine(combatTimer);
                combatTimer = StartCoroutine(CombatTimer());

                hitActors.Add(other.gameObject);

                other.transform.GetComponent<Actor>().combatController.ReceiveHit(transform.position, 1, 5);
            }
            else if (other.gameObject.tag == "Player")
            {
                Debug.Log(other.name);
                inCombat = true;
                if (combatTimer != null)
                    StopCoroutine(combatTimer);
                combatTimer = StartCoroutine(CombatTimer());

                hitActors.Add(other.gameObject);

                other.transform.GetComponent<Actor>().combatController.ReceiveHit(transform.position, 1, 5);
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

    IEnumerator CombatTimer()
    {
        Debug.Log("starting coroutine on "+_owner.name);
        combatTimerRunning = true;
        yield return new WaitForSeconds(3);
        inCombat = false;
        combatTimerRunning = false;
        Debug.Log("ending coroutine on " + _owner.name);
    }
}
