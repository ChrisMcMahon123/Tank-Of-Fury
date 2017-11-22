using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAOE : MonoBehaviour {
	float aoeSpeed;

	void Start () {
		aoeSpeed = 1;
	}

	void Update () {
		aoeSpeed+= 0.1f;

		if(transform.localScale.x < 10)
	 	{
			//grow the AOE until it hits a specific size and then destroy it
			transform.localScale = new Vector3(1,1,1) * aoeSpeed;
		}	
		else 
		{
			Destroy(gameObject);
		}
	}
}