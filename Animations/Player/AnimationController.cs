using UnityEngine;
using System.Collections;

public class AnimationController : MonoBehaviour {

	protected Animator animator;
	
	public float DirectionDampTime = .25f;
	
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	void Update () 
	{
		if(animator) {
			if(Input.GetButtonDown("Jump"))
				animator.SetBool("Jump", true);
			else
				animator.SetBool("Jump", false);

			if(GetComponent<PlayerPhysics>().grounded==false)
				animator.SetBool("Airborne", true );

			else
				animator.SetBool("Airborne", false);                
			
			float h = Input.GetAxis("Horizontal");

			//set event parameters based on user input
			if (GetComponent<PlayerPhysics>().facePlant==true){
				animator.SetFloat("Speed", 0);
				animator.SetFloat("Direction", 0);
			}
			else {
				animator.SetFloat("Speed", h*h);
				animator.SetFloat("Direction", h, DirectionDampTime, Time.deltaTime);
			}
			if(GetComponent<Death>().amIDead == true)
				animator.SetBool("Dead", true);
			else
				animator.SetBool("Dead", false);

			if(Input.GetKeyDown("right"))
			   animator.SetBool("AttackRight", true);
			else
				animator.SetBool("AttackRight", false);
			if(Input.GetKeyDown("left"))
				animator.SetBool("AttackLeft", true);
			else
				animator.SetBool("AttackLeft", false);
		}       
	}
}
