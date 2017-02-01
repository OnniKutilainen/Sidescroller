using UnityEngine;
using System.Collections;

public class EnemyPatrol : MonoBehaviour {
	
	private float useSpeed;
	public float directionSpeed = 9.0f;
	float origX;
	public float distance = 4.0f;
	
	// Use this for initialization
	void Start () {
		origX = transform.position.x;
		useSpeed = -directionSpeed;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(origX - transform.position.x > distance) {
			useSpeed = directionSpeed; //flip direction
		}
		else if(origX - transform.position.x < -distance) {
			useSpeed = -directionSpeed; //flip direction
		}
		transform.Translate(useSpeed*Time.deltaTime,0 ,0);
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag == "LeftAttack") {
			GameObject.FindGameObjectWithTag("Enemy").GetComponent<Rigidbody>().AddForce (new Vector3 (-2f, 0f, 0f) * 17f, ForceMode.Impulse);
		}
	
		if (other.tag == "RightAttack") {
				GameObject.FindGameObjectWithTag("Enemy").GetComponent<Rigidbody>().AddForce (new Vector3 (2f, 0f, 0f) * 17f, ForceMode.Impulse);
		}
	}
}