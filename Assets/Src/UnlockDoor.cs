using UnityEngine;
using System.Collections;

public class UnlockDoor : MonoBehaviour {
	private int unlock = 0;
	private Color green = new Color(0.0f, 1.0f, (65f/255f));
	private Color red = new Color(1.0f, 0.0f, 0.0f);
	private Light _light;
	private Behaviour _nextLevel;

	// Use this for initialization
	void Start () {
		_light = GameObject.Find("Door Light").GetComponent<Light>();
		_nextLevel = GetComponent<NextlevelLoad>();
	}
	
	// Update is called once per frame
	void Update () {
		if(unlock == 2) {
			// "unlock" door
			// change light color
			_light.color = green;
			
			// turn on script
			_nextLevel.enabled = true;
		}
	}

	public void up() {
		unlock++;
	}

	public void down() {
		unlock--;
	}
}
