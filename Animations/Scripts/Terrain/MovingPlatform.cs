using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	private float useSpeed;
	public float directionSpeed = 9.0f;
	float origX;
	public float distance = 4.0f;

	// Use this for initialization
	void Start() {
		origX = transform.position.x;
		useSpeed = -directionSpeed;
	}

	// Update is called once per frame
	void FixedUpdate() {
		if(origX - transform.position.x > distance) {
			useSpeed = directionSpeed; //flip direction
		}
		else if(origX - transform.position.x < -distance) {
			useSpeed = -directionSpeed; //flip direction
		}
		transform.Translate(useSpeed * Time.deltaTime, 0 ,0);
	}

	/*void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			other.GetComponent<PlayerPhysics>().facePlant = true;
			other.transform.Translate((useSpeed + 1f) * Time.deltaTime, 0, 0);
		}
	}*/
}