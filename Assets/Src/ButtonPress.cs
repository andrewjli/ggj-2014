﻿using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {
	private bool inRange = false;
	private bool pressed = false;
	// Use this for initialization
	TimeLord timecont;

	private float timeRemaining;
	void Start () {
		timecont =GameObject.FindObjectOfType<TimeLord> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E) && inRange && !pressed) {
			runPressed();
		} else if (pressed) {
			if (!timecont.isStopped())
				timeRemaining -= Time.deltaTime;
			else if (timecont.isRewinding())
				timeRemaining += Time.deltaTime;
		}
				
		if (pressed && timeRemaining<=0) {
			runUnpressed();
		}
	}

	void OnTriggerEnter (Collider other) {
		inRange = true;
	}

	void OnTriggerExit (Collider other) {
		inRange = false;
	}


	public bool isPressed() {
		return pressed;
	}

	public void setPressed(bool a){
		if (a) {
			if (!pressed)
				runPressed ();
		} else {
			if (pressed)
			runUnpressed();
		}
	}

	void runPressed(){
		pressed = true;
		if(gameObject.name == "Button 3") {
			timeRemaining = 10.0f;
		} else {
			timeRemaining = 5.0f;
		}
		gameObject.transform.position += Vector3.down * 0.2f;
		GameObject.Find("Door").GetComponent<UnlockDoor>().up();
		}

	void runUnpressed(){
		timeRemaining = 0;
		pressed=false;
		gameObject.transform.position += Vector3.up * 0.2f;
		GameObject.Find("Door").GetComponent<UnlockDoor>().down();
	}
}
