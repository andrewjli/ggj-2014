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
	void Start () {}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (unaffectedByTimechange) {
			calculatePos();
				}
		else{
		if (Time.timeScale!=0)
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
