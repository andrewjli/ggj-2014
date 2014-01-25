using UnityEngine;
using System.Collections;

public class audioController : MonoBehaviour {

    public AudioClip[] sounds;
    public CharacterController controller;

	void Start () {
	
	}
	
	
	void Update () {

        if (controller.isGrounded && controller.velocity.magnitude > 1)
        {
           // audio.clip = sounds[0];
           // audio.Play();
        }

	}

    void playPickupSound() // this is called by the timeToken SendMessage
    {
        audio.clip = sounds[1];
        audio.Play();
    }
}
