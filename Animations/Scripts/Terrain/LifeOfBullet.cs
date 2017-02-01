using UnityEngine;
using System.Collections;

public class LifeOfBullet : MonoBehaviour {

	void Update () {
		Destroy (this.gameObject, 5);
	}
}
