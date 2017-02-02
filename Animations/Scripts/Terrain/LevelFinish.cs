using UnityEngine;
using System.Collections;

public class LevelFinish : MonoBehaviour {

	public int GoalCoins = 3;

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player" && GameObject.FindGameObjectWithTag("Player").GetComponent<CollectItem>().collectedCoins == GoalCoins) {

			if (Application.loadedLevel >= PlayerPrefs.GetInt("Level Number")) { 
				PlayerPrefs.SetInt("Level Number", Application.loadedLevel + 1);
			}

			Application.LoadLevel (Application.loadedLevel + 1);
			GameObject.FindGameObjectWithTag("Player").GetComponent<CollectItem>().collectedCoins = 0;
		}
	}
}
