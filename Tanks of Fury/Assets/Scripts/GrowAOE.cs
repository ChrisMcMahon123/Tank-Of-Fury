using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAOE : MonoBehaviour {
	float aoeSpeed;
	int min;
	int max;

	void Start () {
		aoeSpeed = 5.0f;
		min = 1;
		max = 3;
	}

	void Update () {
		//if(transform.localScale.x >= 50)
	//	{
			//grow the AOE until it hits a specific size and then destroy it
			transform.localScale = new Vector3(min + Mathf.PingPong(Time.time, max), min + Mathf.PingPong(Time.time, max), min + Mathf.PingPong(Time.time, max));	//	}
	//	else {
			//Destroy(gameObject);
	//	}
	}

	void OnTriggerEnter(Collider collider)
	{
		//if (collider.tag == "AOEDamage") {
		//destroy the object anytime an object with the AOEDamage tag comes into contact with it
		//emulating the ways of destructable environments
		//Destroy (gameObject);
		Debug.Log("Environment Piece Destroyed by AOE");
		//}
	}
}
