using UnityEngine;
using System.Collections;

public class BofireAniCntrlr : MonoBehaviour {

	protected Animator animator;
	
	public float DirectionDampTime = .25f;

	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(animator)
		{

			if(GameObject.FindGameObjectWithTag("Bonfire").GetComponent<Bonfire>().spawnPoint==this.transform.position)
				animator.SetBool("Lit",true);
			else
				animator.SetBool("Lit",false);

		}       
	}
}
