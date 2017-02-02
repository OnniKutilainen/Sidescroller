using UnityEngine;
using System.Collections;

public class Portal : MonoBehaviour {

	public GameObject portalExit;
	float BDx;
	float BDy;

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {
			other.transform.position = new Vector3(this.portalExit.transform.position.x, this.portalExit.transform.position.y, 0);
			BDx = (this.portalExit.transform.position.x - GameObject.FindGameObjectWithTag("Backdrop").transform.position.x)*0.6f;
			BDy = (this.portalExit.transform.position.y - GameObject.FindGameObjectWithTag("Backdrop").transform.position.y)*0.6f;
			GameObject.FindGameObjectWithTag("Backdrop").transform.position = new Vector3(GameObject.FindGameObjectWithTag("Backdrop").transform.position.x + BDx, GameObject.FindGameObjectWithTag("Backdrop").transform.position.y + BDy, 5);
		}
	}
}
