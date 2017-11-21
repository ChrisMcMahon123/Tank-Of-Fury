using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour {
	int speed;
	// Use this for initialization
	void Start () {
		speed = 25;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//moving the player based on user input
		if (Input.GetKey("up"))
		{
			//move object in the forward direction thats its facing
			Vector3 movement = transform.forward;
			movement.y = transform.position.y;//preserve the y axis to prevent the camera from moving down
			transform.position += movement * speed * Time.deltaTime;
		}

		if (Input.GetKey("down"))
		{
			//move object in the backward direction thats its facing
			Vector3 movement = transform.forward;
			movement.y = transform.position.y;//preserve the y axis to prevent the camera from moving down
			transform.position -= movement * speed * Time.deltaTime;
		}

		if (Input.GetKey("left"))
		{
			//rotate camera left along y axis
			transform.RotateAround(transform.position, Vector3.down, 2 * speed * Time.deltaTime);//rotate around self
		}

		if (Input.GetKey("right"))
		{
			//move camera right along y axis
			transform.RotateAround(transform.position, Vector3.up, 2 * speed * Time.deltaTime);//rotate around self
		}
	}
}
