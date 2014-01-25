using UnityEngine;
using System.Collections;

public class timeController : MonoBehaviour {


    public float timeRemaining;
    public Vector3 currentPosition;

	void Start () {
        currentPosition = this.transform.position;
        

	}
	
	
	void Update () {

        if (currentPosition != this.transform.position)
            timeRemaining -= Time.deltaTime;


        currentPosition = this.transform.position;

        // Debug.Log(timeRemaining);

	}


    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 170, 50), "Time Remaining: " + timeRemaining);
    }


   public float getTime()
    {
        return this.timeRemaining;
    }

    public void setTime(float time)
    {
        timeRemaining = time;
    }
}
