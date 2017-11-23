using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVariables : MonoBehaviour {
	//global variables that any script can access
	public static int moveSpeed = 50;
	public static int jumpSpeed = 1000;
	public static int cannonMultiplier = 1000;
	public static float coolDownPeriod = 1.0f;
	public static float aoeSpeed = 1;
	public static int playerOneCurrentHealth;
	public static int playerOneMaxHealth;
}