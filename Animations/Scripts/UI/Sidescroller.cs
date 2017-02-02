using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class Sidescroller : MonoBehaviour {

	public void StartGame() {
		Application.LoadLevel (1);
	}

	public void ExitGame() {
		Application.Quit();
	}

	public void ContinueGame() {
		GameObject.Find("button_Continue").GetComponent<Image>().enabled = false;
		GameObject.Find("button_Continue").GetComponentInChildren<Text>().enabled = false;
		GameObject.Find("button_ToMainMenu").GetComponent<Image>().enabled = false;
		GameObject.Find("button_ToMainMenu").GetComponentInChildren<Text>().enabled = false;
		GameObject.Find("button_ResetLevel").GetComponent<Image>().enabled = false;
		GameObject.Find("button_ResetLevel").GetComponentInChildren<Text>().enabled = false;
		Time.timeScale = 1;
	}

	public void ReturnToMainMenu() {
		if(Application.loadedLevel == 12){
			PlayerPrefs.SetInt("Level Number", 14);
		}
		Application.LoadLevel (0);
		Time.timeScale = 1;
	}

	public void ResetCurrentLevel() {
		Application.LoadLevel (Application.loadedLevel);
		Debug.Log (Application.loadedLevel);
		Time.timeScale = 1;
	}

	public void ToLevelSelection() {
		Application.LoadLevel ("LevelSelection");
	}

	public void ClearData() {
		PlayerPrefs.SetInt ("Level Number", 1);
		Application.LoadLevel ("LevelSelection");
	}

	public void ChooseLevel1() {
		Application.LoadLevel(1);
	}
	public void ChooseLevel2() {
		Application.LoadLevel(2);
	}
	public void ChooseLevel3() {
		Application.LoadLevel(3);
	}

	public void ChooseLevel4() {
		Application.LoadLevel(4);
	}
	public void ChooseLevel5() {
		Application.LoadLevel(5);
	}
	public void ChooseLevel6() {
		Application.LoadLevel(6);
	}

	public void ChooseLevel7() {
		Application.LoadLevel(7);
	}
	public void ChooseLevel8() {
		Application.LoadLevel(8);
	}
	public void ChooseLevel9() {
		Application.LoadLevel(9);
	}

	public void ChooseLevel10() {
		Application.LoadLevel(10);
	}
	public void ChooseLevel11() {
		Application.LoadLevel(11);
	}
	public void ChooseLevelHelvetti() {
		Application.LoadLevel(14);
	}
}