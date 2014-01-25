using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {
    private bool buttonPressed = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "MainCamera")
        {
            buttonPressed = true;
            print("test");
        }
    }

    public bool isPressed()
    {
        return buttonPressed;
    }
}
