using UnityEngine;
using System.Collections;

public class Dropdown : MonoBehaviour {
    public bool drop;
	// Use this for initialization
	void Start () {
	    drop = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find("BlockadeDropButton").GetComponent<ButtonTrigger>().isPressed())
        {
            drop = true;
        }
        if (drop == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(22.56026f, 7.0f, 82.3804f), 0.1f);
            drop = false;
        }
	}
}
