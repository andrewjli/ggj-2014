using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public Transform endPoint;
    public Transform startPoint;
    public float speed;
    public bool changeDirection;
	public bool unaffectedByTimechange;
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
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
						transform.position = Vector3.MoveTowards (transform.position, startPoint.position, speed);
				} else {
						transform.position = Vector3.MoveTowards (transform.position, endPoint.position, speed);
				}
		}
}
