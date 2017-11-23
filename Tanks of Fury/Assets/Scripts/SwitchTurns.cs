using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTurns : MonoBehaviour {

	public Camera playerOneCamera;
	public GameObject playerOneTank;
	public GameObject playerOneTurret;
	public GameObject playerOneCannon;

	public Camera playerTwoCamera;
	public GameObject playerTwoTank;
	public GameObject playerTwoTurret;
	public GameObject playerTwoCannon;

	void Start() {
		//player 1 starts the game
		GlobalVariables.currentPlayerTank = playerOneTank;
		GlobalVariables.currentPlayerTurret = playerOneTurret;
		GlobalVariables.currentPlayerCannon = playerOneCannon;
		GlobalVariables.CurrentPlayerTurn = 1;
	}

	void Update () {
		if (GlobalVariables.playerOneTurn == true) {
			if (Input.GetKey ("p")) {
				//end player ones turn, start player twos turn
				playerOneCamera.enabled = false;
				GlobalVariables.playerOneTurn = false;

				playerTwoCamera.enabled = true;
				GlobalVariables.playerTwoTurn = true;

				GlobalVariables.currentPlayerTank = playerTwoTank;
				GlobalVariables.currentPlayerTurret = playerTwoTurret;
				GlobalVariables.currentPlayerCannon = playerTwoCannon;

				GlobalVariables.CurrentPlayerTurn = 2;
			}
		} 
		else if (GlobalVariables.playerTwoTurn == true) {
			if (Input.GetKey ("l")) {
				//end player twos turn, start player ones turn
				playerTwoCamera.enabled = false;
				GlobalVariables.playerTwoTurn = false;

				playerOneCamera.enabled = true;
				GlobalVariables.playerOneTurn = true;

				GlobalVariables.currentPlayerTank = playerOneTank;
				GlobalVariables.currentPlayerTurret = playerOneTurret;
				GlobalVariables.currentPlayerCannon = playerOneCannon;

				GlobalVariables.CurrentPlayerTurn = 1;
			}
		}
	}
}