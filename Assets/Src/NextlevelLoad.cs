using UnityEngine;
using System.Collections;

public class NextlevelLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "MainCamera")
		{
			if (this.gameObject.tag=="door1")
				Application.LoadLevel("level2.unity");
			if (this.gameObject.tag=="door2")
				Application.LoadLevel("level3");
		}
	}

}


