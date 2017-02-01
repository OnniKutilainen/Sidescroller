using UnityEngine;
using System.Collections;

public class Bonfire : MonoBehaviour {
	
	public Vector3 spawnPoint;
	public int savedCoins = 0;
	private Death death;
	public Vector3 BackdropPos;

	void Update () {
		if (spawnPoint.x == 0.0 && spawnPoint.y == 0.0 && GameObject.FindGameObjectWithTag("Player")==true){
			spawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
			BackdropPos =GameObject.FindGameObjectWithTag("Backdrop").transform.position;
		}
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Death>().hp = 2;
			spawnPoint = this.transform.position;
			BackdropPos = GameObject.FindGameObjectWithTag("Backdrop").transform.position;
			savedCoins = GameObject.FindGameObjectWithTag("Player").GetComponent<CollectItem>().collectedCoins;
			GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
			for (int i=0;i<coins.Length;i++) {
				if(coins[i].GetComponent<LifeOfCoin>().collected==true)
					coins[i].GetComponent<LifeOfCoin>().saved=true;
			}
			if (other.GetComponent<CollectItem>().doubleJumpActivated == true) {
				other.GetComponent<CollectItem>().doubleJumpSaved = true;
			}

			if (GameObject.Find("Enemy") != null && GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyDamage>().enemyDefeated == true) {
				GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyDamage>().enemyDefeatedSaved = true;
			}
		}
	}
}