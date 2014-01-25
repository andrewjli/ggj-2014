using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimeLord : MonoBehaviour {

	Dictionary<string, ArrayList> gameObjectPositions = new Dictionary<string, ArrayList>();
	Dictionary<string, ArrayList> gameObjectRotations = new Dictionary<string, ArrayList>();

	bool paused = false;

	float time = 1f;

	void Start () {
		foreach (GameObject o in GameObject.FindObjectsOfType(typeof(GameObject)))
		{
            if (o.tag == "TimeTrack")
			{
				gameObjectPositions.Add(o.name, new ArrayList());
				gameObjectRotations.Add(o.name, new ArrayList());
			}
        }
    }
	
	void Update()
	{
		if (Input.GetKey (KeyCode.R))
		{
			rewind ();
		} else if(Input.GetKeyDown(KeyCode.P))
		{
            paused = !paused;
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

		// Lerp time for progressive pause effect, oh and apply it.
		Time.timeScale = (paused) ? 0f: 1f;
	}

	void OnGUI()
	{
		GUI.TextArea(new Rect(25f, 25f, 200f, 25f), string.Format("Game is currently at {0}", time));
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

