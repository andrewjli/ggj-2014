using UnityEngine;
using System.Collections;

public class MagicBall : MonoBehaviour {
	private TimeLord timeController;
	bool hasBeenPaused = false;
	Vector3 storedVelo;
	Vector3 storedAngularVelo;


	// Use this for initialization
	void Start () {
		timeController =GameObject.FindObjectOfType<TimeLord> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (timeController.isStopped ()||timeController.isRewinding()) {
			if (!hasBeenPaused)
			{
				storedVelo= gameObject.GetComponent<Rigidbody> ().velocity;
				gameObject.GetComponent<Rigidbody> ().velocity = new Vector3(0,0,0);
				storedAngularVelo = gameObject.GetComponent<Rigidbody> ().angularVelocity;
				gameObject.GetComponent<Rigidbody> ().angularVelocity = new Vector3(0,0,0);
				gameObject.GetComponent<Rigidbody> ().freezeRotation = true;
				gameObject.GetComponent<Rigidbody> ().Sleep();
				gameObject.GetComponent<Rigidbody> ().useGravity = false;
				hasBeenPaused=true;
			}
				} else {
			if (hasBeenPaused)
			{
				hasBeenPaused=false;
				gameObject.GetComponent<Rigidbody> ().freezeRotation = false;

				gameObject.GetComponent<Rigidbody> ().useGravity = true;
				gameObject.GetComponent<Rigidbody> ().WakeUp();
				gameObject.GetComponent<Rigidbody> ().velocity = storedVelo;
				gameObject.GetComponent<Rigidbody> ().angularVelocity = storedAngularVelo;

			}
				}

	}
}
