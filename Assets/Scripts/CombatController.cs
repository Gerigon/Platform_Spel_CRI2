using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
				public Actor _owner;
				public BoxCollider attackBox;

				// Use this for initialization
				void Start()
				{

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

				public void ReceiveHit()
				{
								Debug.Log("Je Moeder!!!");
				}

				public void PerformAttack()
				{
								//animatorcontroler.playanimation
								attackBox.enabled = true;

				}

				private void OnCollisionEnter(Collision other)
				{
								if (other.collider.gameObject.tag == "Hitbox")
								{
												other.transform.GetComponent<Actor>().combatController.ReceiveHit();
								}
				}
}
