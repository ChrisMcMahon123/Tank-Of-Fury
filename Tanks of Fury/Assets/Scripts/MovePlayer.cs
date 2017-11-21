using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {
	int speed;
	// Use this for initialization
	void Start () {
		speed = 25;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//moving the player based on user input
		if (Input.GetKey("w"))
		{
			//move object in the forward direction thats its facing
			transform.position += transform.right * speed * Time.deltaTime;
		}

		if (Input.GetKey("s"))
		{
			//move object in the backward direction thats its facing
			transform.position -= transform.right * speed * Time.deltaTime;
		}

		if (Input.GetKey("a"))
		{
			//rotate camera left along y axis
			transform.RotateAround(transform.position, Vector3.down, 2 * speed * Time.deltaTime);//rotate around self
		}

		if (Input.GetKey("d"))
		{
			//move camera right along y axis
			transform.RotateAround(transform.position, Vector3.up, 2 * speed * Time.deltaTime);//rotate around self
		}
	}
}