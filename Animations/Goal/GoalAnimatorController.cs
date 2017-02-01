using UnityEngine;
using System.Collections;

public class GoalAnimatorController : MonoBehaviour {
	
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

			if(GameObject.FindGameObjectWithTag("Player").GetComponent<CollectItem>().collectedCoins == GetComponent<LevelFinish>().GoalCoins)
				animator.SetBool("Collected",true);
			else
				animator.SetBool("Collected",false);
			
		}       
	}
}