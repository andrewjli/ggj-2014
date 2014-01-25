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
		yield return new WaitForSeconds(1);

		// Play sound
		
		// Action logic
		
		// Button up
		gameObject.transform.position += Vector3.up * 0.1f;
		pressed = false;
	}
}
