using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour {

	// Update is called once per frame
	void Update () {

		if (PlayerPrefs.GetInt("Level Number") >= 0) {
			GameObject.Find("button_Level1").GetComponent<Button>().interactable = true;
		}

		for (int i=2;i<14;i++){
			string LvlNam = "button_Level"+i;
			if (PlayerPrefs.GetInt("Level Number") >= i) {
				GameObject.Find(LvlNam).GetComponent<Button>().interactable = true;
			}
		}
	}
}
