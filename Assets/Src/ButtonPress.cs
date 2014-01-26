using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
	private bool inRange = false;
	private bool pressed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.E) && inRange && !pressed) {
			StartCoroutine(buttonPress());
		}
	}

	void OnTriggerEnter (Collider other) {
		inRange = true;
	}

	void OnTriggerExit (Collider other) {
		inRange = false;
	}

	IEnumerator buttonPress() {
		pressed = true;
		// Button down
		gameObject.transform.position += Vector3.down * 0.1f;

		// Play sound
		
		// Action logic
		GameObject.Find("Door").GetComponent<UnlockDoor>().up();
		yield return new WaitForSeconds(10);
		
		// Button up
		gameObject.transform.position += Vector3.up * 0.1f;
		GameObject.Find("Door").GetComponent<UnlockDoor>().down();
		pressed = false;
	}

	public bool isPressed() {
		return pressed;
	}
}
