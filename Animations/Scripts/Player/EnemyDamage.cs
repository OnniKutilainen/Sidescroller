using UnityEngine;
using System.Collections;

public class EnemyDamage : MonoBehaviour {

	public int hp = 3;
	public GameObject[] Enemy;
	public bool enemyDefeated = false;
	public bool enemyDefeatedSaved = false;

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		Enemy = GameObject.FindGameObjectsWithTag("Enemy");
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "LeftAttack" || other.tag == "UpAttack" || other.tag == "RightAttack") {
			Debug.Log("Auts");
			hp--;
			if (hp == 0) {
				for (int i=0;i<Enemy.Length;i++) {
					Enemy[i].GetComponent<SpriteRenderer>().enabled = false;
					Enemy[i].GetComponent<BoxCollider>().enabled = false;
					GameObject.FindGameObjectWithTag("EnemyAttLeft").GetComponent<BoxCollider>().enabled = false;
					GameObject.FindGameObjectWithTag("EnemyAttRight").GetComponent<BoxCollider>().enabled = false;
					enemyDefeated = true;
				}
			}
		}
	}
}
