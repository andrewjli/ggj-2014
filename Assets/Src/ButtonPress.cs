using UnityEngine;
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
					}
				
		if (pressed && timeRemaining<=0)
				{
				pressed=false;
				gameObject.transform.position += Vector3.up * 0.3f;
				GameObject.Find("Door").GetComponent<UnlockDoor>().down();
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
			pressed=a;
			timeRemaining=0;
				}
		
	}

	void runPressed(){
		pressed = true;
		timeRemaining = 2.0f;
		gameObject.transform.position += Vector3.down * 0.3f;
		GameObject.Find("Door").GetComponent<UnlockDoor>().up();
		}
}
