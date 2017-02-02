using UnityEngine;
using System.Collections;

public class ShootRight : MonoBehaviour {
	
	public Rigidbody Projectile;
	float fireRate = 1.5f;
	float nextShot = 0f;
	Vector3 projectileClonePos;
	
	void OnTriggerStay (Collider other) {
		
		projectileClonePos = new Vector3(this.gameObject.transform.position.x - 4.125f, this.gameObject.transform.position.y, 0);
		
		if (other.tag == "Player" && Time.time > nextShot) {
			nextShot = Time.time + fireRate;
			Rigidbody projectileClone;
			projectileClone = Instantiate (Projectile, projectileClonePos, Quaternion.identity) as Rigidbody;
			projectileClone.velocity = transform.TransformDirection(Vector3.left * -3);
		}
	}
}