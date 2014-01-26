using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public Transform endPoint;
    public Transform startPoint;
    public float speed;
    public bool changeDirection;
	private bool direction = true;
	public bool unaffectedByTimechange;
	// Use this for initialization

	private TimeLord timeController;

	void Start () {
		timeController = GameObject.FindObjectOfType<TimeLord> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (unaffectedByTimechange) {
			calculatePos();
				}
		else{
			if (!timeController.isStopped())
				calculatePos();
		}
	}

	void calculatePos(){
		if (changeDirection) {
			if (transform.position == endPoint.position){
				direction = true;
			}
			else if (transform.position == startPoint.position){
				direction = false;
			}
			if (direction){
				transform.position = Vector3.MoveTowards (transform.position, startPoint.position, speed);
			}
			else if (!direction){
					transform.position = Vector3.MoveTowards (transform.position, endPoint.position, speed);
			}
		} else {
				transform.position = Vector3.MoveTowards (transform.position, endPoint.position, speed);
		}
	}
}
