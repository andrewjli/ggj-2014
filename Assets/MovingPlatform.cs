using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

    public Transform endPoint;
    public Transform startPoint;
    public float speed;
    public bool changeDirection;
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
        if (transform.position == endPoint.position)
        {
            changeDirection = true;
        }
        if (transform.position == startPoint.position)
        {
            changeDirection = false;
        }
        if (changeDirection)
        {
            transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speed);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, endPoint.position, speed);
        }
	}
}
