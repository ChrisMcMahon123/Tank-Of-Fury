using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowAOE : MonoBehaviour {
	float aoeLocal;

	void Start () {
		aoeLocal = GlobalVariables.aoeSpeed;
	}

	void Update () {
		aoeLocal += 0.1f;

		if(transform.localScale.x < 10) {
			//grow the AOE until it hits a specific size and then destroy it
			transform.localScale = new Vector3(1,1,1) * aoeLocal;
		}	
		else {
			Destroy(gameObject);
		}
	}
}