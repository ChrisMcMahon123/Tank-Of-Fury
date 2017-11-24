using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarOne : MonoBehaviour {
	public GameObject healthBarParent;//parent counting all the health bars

	private GameObject[] healthBars;//local reference to all the health bars
	private int childCount;//number of health bars, allows for change without script editing

	void Start(){
		int childCount = healthBarParent.transform.childCount;

		healthBars = new GameObject[childCount];

		GlobalVariables.playerOneCurrentHealth = childCount;//global referrence for player 1s health
		GlobalVariables.playerOneMaxHealth = childCount;//global referrence for player 1s max health

		for (int i = 0; i < childCount; i++){
			healthBars [i] = healthBarParent.transform.GetChild (i).gameObject;
			//Debug.Log ("Health Bar: " + healthBarParent.transform.GetChild(i));
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "AOEDamage") {
			damageTaken ();
		}

		if (collider.tag == "HealthPack") {
			recoverHealth ();
		}
	}

	public void damageTaken (){
		//Debug.Log ("Damage Taken");
		GlobalVariables.playerOneCurrentHealth--;//subtract a health unit from player1
		healthBars [GlobalVariables.playerOneCurrentHealth].GetComponent<Renderer> ().material = Resources.Load ("Invisible", typeof(Material)) as Material;

		if (GlobalVariables.playerOneCurrentHealth <= 0) {
			Debug.Log ("Player One Died!");
		} 
	}

	public void recoverHealth(){

		if (GlobalVariables.playerOneCurrentHealth == GlobalVariables.playerOneMaxHealth) {
			Debug.Log ("Player 1 is at max health already!");
		} 
		else {
			Debug.Log ("Player 1 Recovered Health");
			healthBars [GlobalVariables.playerOneCurrentHealth].GetComponent<Renderer> ().material = Resources.Load ("Green", typeof(Material)) as Material;
			GlobalVariables.playerOneCurrentHealth++;//subtract a health unit from player1
		}
	}
}