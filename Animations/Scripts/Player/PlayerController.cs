using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerPhysics))]
[RequireComponent(typeof(GameManager))]

public class PlayerController : MonoBehaviour {

	public float speed = 8;
	public float acceleration = 30;
	public float gravity = 24;
	public float jumpHeight = 14;

	private float currentSpeed;
	private float targetSpeed;
	public Vector2 amountToMove;

	private PlayerPhysics playerPhysics;
	private CollectItem collectItem;
	private Bonfire bonfire;

	bool paused = false;
	bool DJumpUsed = false;
	int jumpCounter = 1;

	// Use this for initialization
	void Start () {
		playerPhysics = GetComponent<PlayerPhysics>();
		collectItem = GetComponent<CollectItem>();
	}
	
	// Update is called once per frame
	void Update () {

		PauseCheck ();

		if (playerPhysics.facePlant) {
			targetSpeed = 0;
			currentSpeed = 0;
		}

		if (playerPhysics.grounded) {
			amountToMove.y = 0;
			DJumpUsed = false;
		}

		targetSpeed = Input.GetAxisRaw ("Horizontal") * speed;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);

		// Jump
		if ((Input.GetButtonDown ("Jump") || Input.GetButtonDown ("Vertical")) && playerPhysics.grounded) {
			amountToMove.y = jumpHeight;
			jumpCounter++;
		}

		// Dubbel jumppi
		else if ((Input.GetButtonDown ("Jump") || Input.GetButtonDown ("Vertical")) && DJumpUsed == false && collectItem.doubleJumpActivated == true && !playerPhysics.grounded) {
			amountToMove.y = jumpHeight;
			DJumpUsed = true;
		}

		/* Wall Jump
		if ((Input.GetButtonDown ("Jump") || Input.GetButtonDown ("Vertical")) && playerPhysics.facePlant && !playerPhysics.grounded) {
			amountToMove.y = jumpHeight-6f;
			GameObject.FindGameObjectWithTag("Player").rigidbody.AddForce(new Vector3(Mathf.Sign(-amountToMove.x), 0f, 0f) * 24f, ForceMode.Impulse);
		}*/

		amountToMove.x = currentSpeed;
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move (amountToMove * Time.deltaTime);
	}

	// Increase n towards target by speed
	private float IncrementTowards(float n, float target, float a) {

		if (n == target) {
			return n;
		} 
		else {
			float dir = Mathf.Sign (target - n); // Must n be increased or decreased to get closer to target
			n += a * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - n)) ? n : target; // if n has now passed target then return target, otherwise return n
		}
	}

	void PauseCheck() {

		if (Input.GetKeyDown(KeyCode.Escape) && paused == false) {
			GameObject.Find("button_Continue").GetComponent<Image>().enabled = true;
			GameObject.Find("button_Continue").GetComponentInChildren<Text>().enabled = true;
			GameObject.Find("button_ToMainMenu").GetComponent<Image>().enabled = true;
			GameObject.Find("button_ToMainMenu").GetComponentInChildren<Text>().enabled = true;
			GameObject.Find("button_ResetLevel").GetComponent<Image>().enabled = true;
			GameObject.Find("button_ResetLevel").GetComponentInChildren<Text>().enabled = true;
			
			Time.timeScale = 0;
			paused = true;
		}
		
		else if (Input.GetKeyDown(KeyCode.Escape) && paused == true) {
			GameObject.Find("button_Continue").GetComponent<Image>().enabled = false;
			GameObject.Find("button_Continue").GetComponentInChildren<Text>().enabled = false;
			GameObject.Find("button_ToMainMenu").GetComponent<Image>().enabled = false;
			GameObject.Find("button_ToMainMenu").GetComponentInChildren<Text>().enabled = false;
			GameObject.Find("button_ResetLevel").GetComponent<Image>().enabled = false;
			GameObject.Find("button_ResetLevel").GetComponentInChildren<Text>().enabled = false;
			
			Time.timeScale = 1;
			paused = false;
		}
	}
}