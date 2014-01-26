using UnityEngine;
using System.Collections;

public class UnlockDoor : MonoBehaviour {
	private int unlock = 0;
	private Color green = new Color(0.0f, 1.0f, (65f/255f));
	private Color red = new Color(1.0f, 0.0f, 0.0f);
	private Light _light;
	private NextlevelLoad _nextLevel;

	// Use this for initialization
	void Start () {
		_light = GameObject.Find("Door Light").GetComponent<Light>();
		_nextLevel = GetComponent<NextlevelLoad>();
		if (gameObject.tag == "door5" || gameObject.tag == "door6")
			_nextLevel.doorUnlocked = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject.tag == "door5") {
			if(unlock == 2) {
				// "unlock" door
				// change light color
				_light.color = green;
				
				// turn on script
				_nextLevel.doorUnlocked = true;
			}
		}
		if(gameObject.tag == "door6") {
			if(unlock == 1) {
				// "unlock" door
				// change light color
				_light.color = green;
				
				// turn on script
				_nextLevel.doorUnlocked = true;
			} else {
				_light.color = red;
				_nextLevel.doorUnlocked = false;
			}
		}
	}

	public void up() {
		unlock++;
	}

	public void down() {
		unlock--;
	}
}
