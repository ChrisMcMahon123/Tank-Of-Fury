using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSphere : MonoBehaviour {
	public GameObject playerSphere;

	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = gameObject.transform.position - playerSphere.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		gameObject.transform.position = playerSphere.transform.position + offset;
	}
}
