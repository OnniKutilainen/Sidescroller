using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

	private GameObject left;
	private GameObject right;

	float attackDelay = 1f;
	float nextAttack = 0f;

	// Use this for initialization
	void Start () {
		left = GameObject.Find("LeftAttack");
		right = GameObject.Find ("RightAttack");
	
	}

	void Update() {
		StartCoroutine(("Kakkendaali"));
	}
	// Update is called once per frame
	IEnumerator Kakkendaali() {
		if (Input.GetKeyDown("left") && Time.time > nextAttack) {
			left.GetComponent<BoxCollider>().enabled = true;
			left.GetComponent<BoxCollider>().isTrigger = true;
			nextAttack = Time.time + attackDelay;
			Debug.Log("Attacked left at " + Time.time);
			yield return new WaitForSeconds(1);
			left.GetComponent<BoxCollider>().enabled = false;
			left.GetComponent<BoxCollider>().isTrigger = false;
			Debug.Log("Left attack ended at " + Time.time);
		}
		
		if (Input.GetKeyDown("right") && Time.time > nextAttack) {
			right.GetComponent<BoxCollider>().enabled = true;
			right.GetComponent<BoxCollider>().isTrigger = true;
			nextAttack = Time.time + attackDelay;
			Debug.Log("Attacked right at " + Time.time);
			yield return new WaitForSeconds(1);
			right.GetComponent<BoxCollider>().enabled = false;
			right.GetComponent<BoxCollider>().isTrigger = false;
			Debug.Log("Right attack ended at " + Time.time);
		}
	}
}
