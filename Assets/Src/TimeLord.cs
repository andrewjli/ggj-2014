using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeLord : MonoBehaviour {

	Dictionary<string, ArrayList> gameObjectPositions = new Dictionary<string, ArrayList>();
	Dictionary<string, ArrayList> gameObjectRotations = new Dictionary<string, ArrayList>();
	private CharacterController character;
	bool paused = false;
	Light timeLight;

	public float rewindAmount;
	private float timeElapsed;

	float time = 1f;

	public void addRewindTime(float f){
				rewindAmount += f;
		}

	void Start () {
		timeLight = GameObject.Find("TimeLight").GetComponent<Light>();
		timeElapsed = 0;
		foreach (GameObject o in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
            if (o.tag == "TimeTrack")
			{
				gameObjectPositions.Add(o.name, new ArrayList());
				gameObjectRotations.Add(o.name, new ArrayList());
			}
			if (o.tag == "MainCamera")
				character =  o.GetComponent<CharacterController>();
        }
    }

	void Update()
	{
		if (Input.GetKey (KeyCode.Q)) {
			Application.LoadLevel(Application.loadedLevel);
		}
		bool isMoving = character.velocity.magnitude > 0 || Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.A) 
			|| Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.Space)
				|| Input.GetKey (KeyCode.R);

		if (!isMoving) {
						paused = true;
				} else {
						paused = false;
				}

		bool isRewinding = false;
		if (Input.GetKey (KeyCode.R))
		{
			if (rewindAmount>0)
			{
			isRewinding=true;
			rewind ();
			}
		} else {
			// Not rewinding
			foreach (GameObject o in GameObject.FindObjectsOfType (typeof(GameObject)))
			{
				if (o.tag == "TimeTrack" && !paused)
                {
					gameObjectPositions[o.name].Add (
						new Vector3(
							o.transform.position.x,
							o.transform.position.y,
							o.transform.position.z)
						);     
					gameObjectRotations[o.name].Add(
						new Quaternion(
							o.transform.rotation.x,
							o.transform.rotation.y,
							o.transform.rotation.z,
							o.transform.rotation.w)
						);         
				}
            }
        }

		if (isRewinding) {
				rewindAmount =Mathf.Max (0, rewindAmount - Time.deltaTime);
				timeElapsed = Mathf.Max (0, timeElapsed - Time.deltaTime);
	timeLight.color= new Color(0,255,192);
			timeLight.color= new Color(0.0f,255.0f/255.0f,192.0f/255.0f,1.0f);

				}
				else {
			if (isMoving)
			{
				timeElapsed += Time.deltaTime;
				timeLight.color= new Color(255.0f/255.0f,121.0f/255.0f,0.0f,1.0f);
			}
			else
			{
				timeLight.color= new Color(0.0f,0.0f,0.0f,1.0f);
			}
				}

		// Lerp time for progressive pause effect, oh and apply it.
		Time.timeScale = (paused) ? 0f: 1f;
	}

	void OnGUI()
	{
		GUI.Box(new Rect(10, 10, 170, 50), "Time Elapsed: " + timeElapsed.ToString("F1")+"\nReplay Seconds: "+rewindAmount.ToString("F1"));
	}

	public void rewind()
	{
		foreach (GameObject o in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
			if (o.tag == "TimeTrack")
			{
                string key = o.name;
				ArrayList t = (ArrayList) gameObjectPositions[key];
				ArrayList tRot = (ArrayList) gameObjectRotations[key];


				if (t.Count>0)
				{
					//o.transform.position = ((Transform) t[lastFrame]).position;
					o.transform.position =  ((Vector3) t[t.Count-1]);
					o.transform.rotation = ((Quaternion) tRot[t.Count-1]);
                    if (t.Count > 1)
                    {
                        t.RemoveAt(t.Count-1);
                        tRot.RemoveAt(tRot.Count-1);

                        gameObjectPositions[key]=t;
                        gameObjectRotations[key]=tRot;
                    }
				}
			}
        }
	}
}

