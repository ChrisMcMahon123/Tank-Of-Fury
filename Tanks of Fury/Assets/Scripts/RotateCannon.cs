using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour {
	void Update () {
		if (Input.GetKey("z"))
		{
			if (transform.localEulerAngles.y > 140) {
				//rotate the cannon up
				transform.Rotate (Vector3.left * 2 * GlobalVariables.moveSpeed * Time.deltaTime);
			} 
		}

		if (Input.GetKey ("c")) {
			if (transform.localEulerAngles.y < 180) {
				//rotate the cannon down
				transform.Rotate (Vector3.right * 2 * GlobalVariables.moveSpeed * Time.deltaTime);
			}
		}
	}
}