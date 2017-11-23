using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalVariables : MonoBehaviour {
	//global constant variables that any script can access
	public static int moveSpeed = 50;
	public static int jumpSpeed = 350;
	public static int cannonMultiplier = 1000;
	public static float coolDownPeriod = 2.0f;
	public static float aoeSpeed = 1;

	//Player 1
	public static bool playerOneTurn = true;
	public static int playerOneCurrentHealth;
	public static int playerOneMaxHealth;

	//Player 2
	public static bool playerTwoTurn = false;
	public static int playerTwoCurrentHealth;
	public static int playerTwoMaxHealth;

	//Current Players Turn Game Objects for 
	public static int CurrentPlayerTurn;
	public static GameObject currentPlayerTank;
	public static GameObject currentPlayerTurret;
	public static GameObject currentPlayerCannon;
}