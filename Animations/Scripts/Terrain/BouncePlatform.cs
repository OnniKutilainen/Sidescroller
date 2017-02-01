using UnityEngine;
using System.Collections;

public class BouncePlatform : MonoBehaviour {

	public float bounceForce = 25f;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPhysics>().grounded = false;
			other.GetComponent<Rigidbody>().AddForce(Vector3.up * bounceForce , ForceMode.Impulse);
			GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().amountToMove.y = 13;
		}
	}
}
