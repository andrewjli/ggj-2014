using UnityEngine;
using System.Collections;

public class audioController : MonoBehaviour {

    public AudioClip[] sounds;
    public CharacterController controller;
    private bool step = true; 
    float audioStepLengthWalk = 0.25f; 
    

	void Start () {
	
	}
	
	
	void Update () {

        if (controller.isGrounded && controller.velocity.magnitude > 1 && step == true)
        {
            audio.clip = sounds[0];
            audio.Play();

            StartCoroutine(WaitForFootSteps(audioStepLengthWalk));
        }

	}

    void playPickupSound() // this is called by the timeToken SendMessage
    {
        audio.Stop();
        audio.clip = sounds[1];
        audio.Play();
        
    }

    IEnumerator WaitForFootSteps(float stepsLength) 
    { 
        this.step = false; 
        yield return new WaitForSeconds(stepsLength); 
        step = true; 
    }
}
