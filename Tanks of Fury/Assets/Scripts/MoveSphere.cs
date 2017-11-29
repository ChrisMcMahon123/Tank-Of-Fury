using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour {
	float speed = 100;
	public Camera camera;
	public GameObject tank;

	Vector3 cameraOffset;
	Vector3 tankOffset;

	void Start () {
		cameraOffset = camera.transform.position - gameObject.transform.position;
		tankOffset = tank.transform.position - gameObject.transform.position;
	}

	void Update () {
		camera.transform.position = gameObject.transform.position + cameraOffset;
		tank.transform.position = gameObject.transform.position + tankOffset;

		if (Input.GetKey("w"))
		{
			GetComponent<Rigidbody>().AddForce(camera.transform.forward * speed * Time.deltaTime);
		}

		if (Input.GetKey("s"))
		{
			GetComponent<Rigidbody>().AddForce(camera.transform.forward * (-1) * speed * Time.deltaTime);
		}

		if (Input.GetKey("a"))
		{
			camera.transform.RotateAround (gameObject.transform.position, Vector3.up,(-1) * speed * Time.deltaTime);
			cameraOffset = camera.transform.position - gameObject.transform.position;
		
			tank.transform.RotateAround (gameObject.transform.position, Vector3.up,(-1) * speed * Time.deltaTime);
			tankOffset = tank.transform.position - gameObject.transform.position;
		}

		if (Input.GetKey("d"))
		{
			camera.transform.RotateAround (gameObject.transform.position, Vector3.up, speed * Time.deltaTime);
			cameraOffset = camera.transform.position - gameObject.transform.position;

			tank.transform.RotateAround (gameObject.transform.position, Vector3.up, speed * Time.deltaTime);
			tankOffset = tank.transform.position - gameObject.transform.position;
		}
	}
}
