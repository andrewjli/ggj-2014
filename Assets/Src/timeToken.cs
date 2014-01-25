using UnityEngine;
using System.Collections;

public class timeToken : MonoBehaviour {


    public float rotationalSpeed;
    public float timeBonus;

	void Start () {
	
	}
	
	void Update () {

        transform.Rotate(new Vector3(0, 0, rotationalSpeed));

	}

    void OnTriggerEnter(Collider other)
    {
        addTime();
        Camera.main.SendMessage("playPickupSound");
        Destroy(this.gameObject);
    }

    void addTime()
    {

		TimeLord t =GameObject.FindObjectOfType<TimeLord> ();
		t.addRewindTime (timeBonus);

    }
}
