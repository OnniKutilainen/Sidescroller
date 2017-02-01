using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CollectItem : MonoBehaviour {

	Text txt;
	[HideInInspector]
	public bool doubleJumpActivated = false;
	public bool doubleJumpSaved = false;

	void Start() {
		txt = GameObject.Find("text_Coins").GetComponent<Text>();
		txt.text = "Coins: " + collectedCoins;
	}
	
	public int collectedCoins = 0;
	
	void OnTriggerEnter (Collider other) {

		if (other.tag == "Coin") {
			other.gameObject.GetComponent<MeshRenderer>().enabled = false;
			other.gameObject.GetComponent<BoxCollider>().enabled = false;
			collectedCoins++;
			other.gameObject.GetComponent<LifeOfCoin>().collected = true;
		}

		if (other.tag == "Doublejump") {
			Debug.Log("Douplejump aktiveitted");
			other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			other.gameObject.GetComponent<BoxCollider>().enabled = false;
			doubleJumpActivated = true;
		}

	}

	void Update() {
		txt.text = "Coins: " + collectedCoins;
	}
}