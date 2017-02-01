using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Death : MonoBehaviour {

	Text txt;
	public bool amIDead = false;
	public bool DangerLeft = false;
	public bool DangerRight = false;
	public GameObject player;
	private Bonfire bonfire;
	public int hp = 2;
	public GameObject[] Projectiles;
	private EnemyDamage enemy;

	void Start() {
		bonfire = GameObject.FindGameObjectWithTag("Bonfire").GetComponent<Bonfire>();
		txt = GameObject.Find("text_HP").GetComponent<Text>();
		txt.text = "Health: 00";


	}

	void Update() {
		if (hp == 2)
			txt.text = "Health: 00";
		else if (hp == 1)
			txt.text = "Health: 0";
		else
			txt.text = "Health: DEATH!";
		Projectiles = GameObject.FindGameObjectsWithTag("Projectile");

		if (GameObject.Find("Enemy") != null) {
			enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyDamage>();
		}
	}
	
	IEnumerator OnTriggerEnter (Collider other) {
		if (other.tag == "Projectile") {
			player.GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0f, 0f) * 17f, ForceMode.Impulse);
			GameObject.FindGameObjectWithTag("Backdrop").GetComponent<Rigidbody>().AddForce(new Vector3(-0.6f, 0f, 0f) * 17f, ForceMode.Impulse);
			Destroy(other.gameObject);
			hp--;
		}

		if (other.tag == "ProjectileRight") {
			player.GetComponent<Rigidbody>().AddForce(new Vector3(1f, 0f, 0f) * 17f, ForceMode.Impulse);
			GameObject.FindGameObjectWithTag("Backdrop").GetComponent<Rigidbody>().AddForce(new Vector3(0.6f, 0f, 0f) * 17f, ForceMode.Impulse);
			Destroy(other.gameObject);
			hp--;
		}

		if (other.tag == "EnemyAttLeft") {
			DangerLeft = true;
			player.GetComponent<Rigidbody>().AddForce(new Vector3(-2f, 0f, 0f) * 17f, ForceMode.Impulse);
			GameObject.FindGameObjectWithTag("Backdrop").GetComponent<Rigidbody>().AddForce(new Vector3(-1.2f, 0f, 0f) * 17f, ForceMode.Impulse);
			hp--;
			GameObject.FindGameObjectWithTag ("EnemyAttLeft").GetComponent<BoxCollider> ().enabled = false;
			yield return new WaitForSeconds(0.2f);
			DangerLeft = false;
			yield return new WaitForSeconds(0.3f);
			GameObject.FindGameObjectWithTag ("EnemyAttLeft").GetComponent<BoxCollider> ().enabled = true;

		}

		if (other.tag == "EnemyAttRight") {
			DangerRight = true;
			player.GetComponent<Rigidbody>().AddForce(new Vector3(2f, 0f, 0f) * 17f, ForceMode.Impulse);
			GameObject.FindGameObjectWithTag("Backdrop").GetComponent<Rigidbody>().AddForce(new Vector3(1.2f, 0f, 0f) * 17f, ForceMode.Impulse);
			hp--;
			GameObject.FindGameObjectWithTag ("EnemyAttRight").GetComponent<BoxCollider> ().enabled = false;
			yield return new WaitForSeconds(0.2f);
			DangerRight = false;
			yield return new WaitForSeconds(0.3f);
			GameObject.FindGameObjectWithTag ("EnemyAttRight").GetComponent<BoxCollider> ().enabled = true;
		}

		if (other.tag == "DEATH") {
			hp=0;
			DoDeathFall ();
			yield return new WaitForSeconds(0.5f);
			DoDeathStuff ();
		}
		if (hp == 0) {
			DoDeathAni ();
			yield return new WaitForSeconds(2.3f);
			DoDeathStuff ();
		}
	}

	void DoDeathStuff() {
		GameObject[] coins = GameObject.FindGameObjectsWithTag("Coin");
		GameObject.FindGameObjectWithTag("Player").transform.position = bonfire.spawnPoint;
		GameObject.FindGameObjectWithTag("Backdrop").transform.position = bonfire.BackdropPos;
		gameObject.GetComponent<CollectItem>().collectedCoins = GameObject.FindGameObjectWithTag("Bonfire").GetComponent<Bonfire>().savedCoins;

		for (int i=0;i<coins.Length;i++) {
			if(coins[i].GetComponent<LifeOfCoin>().saved==false) {
				coins[i].GetComponent<MeshRenderer>().enabled = true;
				coins[i].GetComponent<BoxCollider>().enabled = true;
				coins[i].GetComponent<LifeOfCoin>().collected=false;
			}
		}
		GetComponent<PlayerController> ().enabled = true;
		GameObject.FindGameObjectWithTag ("Backdrop").GetComponent<BackdropScrolling> ().enabled = true;
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<GameCamera> ().enabled = true;
		amIDead = false;
		hp = 2;

		for(int i = 0; i < Projectiles.Length; i++)
		{
			Destroy(Projectiles[i].gameObject);
		}
		if (GameObject.Find("Enemy") != null) {
			for(int i = 0; i < enemy.Enemy.Length; i++) {
				if(enemy.enemyDefeatedSaved == false) {
					enemy.Enemy[i].GetComponent<SpriteRenderer>().enabled = true;
					enemy.Enemy[i].GetComponent<BoxCollider>().enabled = true;
					GameObject.FindGameObjectWithTag("EnemyAttLeft").GetComponent<BoxCollider>().enabled = true;
					GameObject.FindGameObjectWithTag("EnemyAttRight").GetComponent<BoxCollider>().enabled = true;
					enemy.hp = 3;
				}
			}
		}

		if (GetComponent<CollectItem>().doubleJumpSaved == false) {
			GetComponent<CollectItem>().doubleJumpActivated = false;
			GameObject.FindGameObjectWithTag("Doublejump").GetComponent<SpriteRenderer>().enabled = true;
			GameObject.FindGameObjectWithTag("Doublejump").GetComponent<BoxCollider>().enabled = true;
		}

	}

	void DoDeathAni() {

		amIDead = true;
		GetComponent<PlayerController> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Backdrop").GetComponent<BackdropScrolling> ().enabled = false;
		Debug.Log("Ded!");
	}

	void DoDeathFall() {
		
		amIDead = true;
		GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<GameCamera> ().enabled = false;
		GameObject.FindGameObjectWithTag ("Backdrop").GetComponent<BackdropScrolling> ().enabled = false;
		Debug.Log("Ded!");
	}
}
