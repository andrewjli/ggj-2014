using UnityEngine;
using System.Collections;

public class NextlevelLoad : MonoBehaviour {
	public bool doorUnlocked = true;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "MainCamera" && doorUnlocked)
		{
			if (this.gameObject.tag=="door1"){
				Application.LoadLevel("level2");}
			if (this.gameObject.tag=="door2"){
				Application.LoadLevel("level3");}
			if (this.gameObject.tag=="door3"){
				Application.LoadLevel("level4");}
			if (this.gameObject.tag=="door4"){
				Application.LoadLevel("level5");}
			if (this.gameObject.tag=="door5"){
				Application.LoadLevel("level6");}
			if (this.gameObject.tag=="door6"){
				Application.LoadLevel("levelcredits");}
		}
	}
}