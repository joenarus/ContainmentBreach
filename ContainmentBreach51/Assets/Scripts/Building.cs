using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
	private AlienBehavior temp;
	public int fireRate;
	public int damage;
	bool attacking;
	List <AlienBehavior> enemies = new List<AlienBehavior>();
	int CurrentAttackingIndex = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other) {

		if (other.tag == "alien") {
			if (!attacking) {
				Debug.Log ("Hi");
				attacking = true;
				temp = other.GetComponent<AlienBehavior> ();
				InvokeRepeating ("Attack",.01f, fireRate);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		temp = other.GetComponent<AlienBehavior> ();
		enemies.Add(temp);
	}

	void OnTriggerExit(Collider other) {
		CurrentAttackingIndex++;
		attacking = false;

	}
		
	void Attack() {
		if (enemies [CurrentAttackingIndex] != null) {
			enemies [CurrentAttackingIndex].takeDamage (damage);
		}
		if (enemies[CurrentAttackingIndex].health <= 0) {
			CurrentAttackingIndex++;

		}

		if (CurrentAttackingIndex > enemies.Count - 1) {
			CancelInvoke ();
			attacking = false;
		}
	}
}
