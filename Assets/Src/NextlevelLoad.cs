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
			if (this.tag=="door1")
				Application.LoadLevel("level2");
			if (this.tag=="door2")
				Application.LoadLevel("level3");
		}
	}

}


