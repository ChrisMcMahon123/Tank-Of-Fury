using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour {
	float speed = 25;

	void Update () {
		if (Input.GetKey("w") || (Input.GetKey("up")))
		{
			GetComponent<Rigidbody>().AddForce(Vector3.forward * speed * Time.deltaTime);
		}

		if (Input.GetKey("s") || (Input.GetKey("down")))
		{
			GetComponent<Rigidbody>().AddForce(Vector3.back * speed * Time.deltaTime);
		}

		if (Input.GetKey("a") || (Input.GetKey("left")))
		{
			GetComponent<Rigidbody>().AddForce(Vector3.left * speed * Time.deltaTime);
		}

		if (Input.GetKey("d") || (Input.GetKey("right")))
		{
			GetComponent<Rigidbody>().AddForce(Vector3.right * speed * Time.deltaTime);
		}
	}
}
