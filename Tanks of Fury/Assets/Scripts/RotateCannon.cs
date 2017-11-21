using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCannon : MonoBehaviour {
	int speed;
	// Use this for initialization
	void Start () {
		speed = 25;			
		//Debug.Log ("Rotation Angle:: " + transform.localEulerAngles);
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKey("z"))
		{
			if (transform.localEulerAngles.y > 140) {
				//rotate the cannon up
				transform.Rotate (Vector3.left * 2 * speed * Time.deltaTime);
			} 
		}

		if (Input.GetKey ("c")) {
			if (transform.localEulerAngles.y < 180) {
				//rotate the cannon down
				transform.Rotate (Vector3.right * 2 * speed * Time.deltaTime);
			}
		}
	}
}
