using UnityEngine;
using System.Collections;

public class BackdropScrolling : MonoBehaviour {
	
	public Vector2 Movement;
	// Use this for initialization
	void Start () {
		if (GameObject.FindGameObjectWithTag ("Player") == true) {
			Movement = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerPhysics> ().MoveExport;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move (Movement * Time.deltaTime);
	}

	void Move (Vector2 moveAmount) {
		Movement = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerPhysics> ().MoveExport;
		transform.Translate (Movement * 0.5f);
	}
}
