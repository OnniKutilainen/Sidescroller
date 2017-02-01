using UnityEngine;
using System.Collections;

public class EnemyAnimationCntrlr : MonoBehaviour {

	protected Animator animator;
	
	public float DirectionDampTime = .25f;
	// Use this for initialization
	void Start () {

		animator = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Death> ().DangerLeft == true)
			animator.SetBool ("AttLeft", true);
		else
			animator.SetBool ("AttLeft", false);

		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<Death> ().DangerRight == true)
			animator.SetBool ("AttRight", true);
		else
			animator.SetBool ("AttRight", false);
	}
}
