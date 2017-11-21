using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTurret : MonoBehaviour {
	int speed;
	// Use this for initialization
	void Start () {
		speed = 25;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("q"))
		{
			//rotate camera left along y axis
			transform.RotateAround(transform.position, Vector3.down, 2 * speed * Time.deltaTime);//rotate around self
		}

		if (Input.GetKey("e"))
		{
			//move camera right along y axis
			transform.RotateAround(transform.position, Vector3.up, 2 * speed * Time.deltaTime);//rotate around self
		}
	}
}
