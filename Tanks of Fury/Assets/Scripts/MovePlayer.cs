using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//camera will now follow player, camera controls are currently disabled
public class MovePlayer : MonoBehaviour {
	bool isGrounded;

	void Update () {
		//moving the player based on user input
		if (Input.GetKey("w")) {
			//move object in the forward direction thats its facing
			transform.position += transform.forward * GlobalVariables.moveSpeed * Time.deltaTime;
		}

		if (Input.GetKey("s")) {
			//move object in the backward direction thats its facing
			transform.position -= transform.forward * GlobalVariables.moveSpeed * Time.deltaTime;
		}

		if (Input.GetKey("a")) {
			//rotate camera left along y axis
			transform.RotateAround(transform.position, Vector3.down, 2 * GlobalVariables.moveSpeed * Time.deltaTime);//rotate around self
		}

		if (Input.GetKey("d")) {
			//move camera right along y axis
			transform.RotateAround(transform.position, Vector3.up, 2 * GlobalVariables.moveSpeed * Time.deltaTime);//rotate around self
		}

		if (Input.GetKeyDown ("space")) {
			if (isGrounded == true) {
				transform.Translate (Vector3.up * GlobalVariables.jumpSpeed * Time.deltaTime, Space.World);
			}
		} 
	}

	void OnCollisionEnter(Collision collision) {
		isGrounded = true;//the player has returned to the 'ground'
	}

	void OnCollisionExit(Collision collision) {	
		isGrounded = false;//the player has gone airborne, don't let them jump
	}
}