using UnityEngine;
using System.Collections;

public class KillProjectile : MonoBehaviour {
	
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Projectile") {
			Destroy(other.gameObject);
		}
		if (other.tag == "ProjectileRight") {
			Destroy(other.gameObject);
		}
	}
}
