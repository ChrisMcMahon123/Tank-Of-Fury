using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarTwo : MonoBehaviour {
	public GameObject healthBarParent;//parent counting all the health bars

	private GameObject[] healthBars;//local reference to all the health bars
	private int childCount;//number of health bars, allows for change without script editing

	void Start(){
		int childCount = healthBarParent.transform.childCount;

		healthBars = new GameObject[childCount];

		GlobalVariables.playerTwoCurrentHealth = childCount;//global referrence for player 1s health
		GlobalVariables.playerTwoMaxHealth = childCount;//global referrence for player 1s max health

		for (int i = 0; i < childCount; i++){
			healthBars [i] = healthBarParent.transform.GetChild (i).gameObject;
			//Debug.Log ("Health Bar: " + healthBarParent.transform.GetChild(i));
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "AOEDamage") {
			damageTaken ();
		}
	}

	public void damageTaken (){
		//Debug.Log ("Damage Taken");
		GlobalVariables.playerTwoCurrentHealth--;//subtract a health unit from player1
		healthBars [GlobalVariables.playerTwoCurrentHealth].GetComponent<Renderer> ().material = Resources.Load ("Invisible", typeof(Material)) as Material;

		if (GlobalVariables.playerTwoCurrentHealth <= 0) {
			Debug.Log ("Player 2 Died!");
		}
	}
}