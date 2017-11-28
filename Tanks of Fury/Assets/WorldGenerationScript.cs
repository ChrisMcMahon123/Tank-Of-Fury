using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerationScript : MonoBehaviour {

	//Array to store terrain objects
	[SerializeField]
	private GameObject [] trees;
	[SerializeField]
	private GameObject[] stones;

	[SerializeField]
	private GameObject[] terrain;

	public int stoneChances = 6;

	[SerializeField]
	private GameObject blMarker;
	[SerializeField]
	private GameObject trMarker;

	//Grid position
	private Vector3 currentPosition;
	private Vector3 worldObjectStartPos;
	private Vector3 terrainStartPos;

	private float groundWidth;

	private float worldObjectIncAmount;
	private float terrainIncAmount;

	private float worldObjectRandAmount;
	private float terrainRandAmount;
	 
	[SerializeField]
	private int worldObjectRowsCols;
	[SerializeField]
	private int terrainRowsCols;

	//number of cycles and current cycles the loop is generating
	[SerializeField]
	public int repeatCycle;
	[SerializeField]
	public int currentGeneration;

	[SerializeField]
	private float worldObjectSphereRadius;
	[SerializeField]
	private float terrainRadius;

	[SerializeField]
	private LayerMask groundLayer;
	[SerializeField]
	private LayerMask terrainLayer;
	[SerializeField]
	private LayerMask worldObjectLayer;


	// Use this for initialization
	void Start () {
		StartCoroutine ("PopulateWorld");
	}
	
	IEnumerator PopulateWorld(){
		groundWidth = trMarker.transform.position.x - blMarker.transform.position.x;

		worldObjectIncAmount = groundWidth / worldObjectRowsCols;
		worldObjectRandAmount = worldObjectIncAmount / 2f;

		terrainIncAmount = groundWidth / worldObjectRowsCols;
		terrainRandAmount = terrainIncAmount / 2f;

		worldObjectStartPos = new Vector3 (blMarker.transform.position.x - (worldObjectIncAmount/2f), blMarker.transform.position.y,
			blMarker.transform.position.z + (worldObjectIncAmount/2f));
		terrainStartPos = new Vector3 (blMarker.transform.position.x - (terrainIncAmount / 2f), blMarker.transform.position.y, 
			blMarker.transform.position.z + (terrainIncAmount / 2f));


		for (int repeat = 0; repeat <= repeatCycle; repeat++) {
			currentGeneration = repeat;

			if (currentGeneration == 0) {
				currentPosition = terrainStartPos;

				for (int cols = 1; cols <= terrainRowsCols; cols++) {
					for (int rows = 1; rows <= terrainRowsCols; rows++) {
						currentPosition = new Vector3 (currentPosition.x + terrainIncAmount, currentPosition.y, currentPosition.z);
						GameObject newSpawn = terrain [Random.Range (0, terrain.Length)];

						spawnHere (currentPosition, newSpawn, terrainRadius, true);

						yield return new WaitForSeconds (0.01f);
					}

					currentPosition = new Vector3 (terrainStartPos.x, currentPosition.y, currentPosition.z + terrainIncAmount); 
				}
			} 
			else if (currentGeneration > 0) {
				currentPosition = worldObjectStartPos;

				for (int cols = 1; cols <= worldObjectRowsCols; cols++) {
					for (int rows = 1; rows <= worldObjectRowsCols; rows++) {
						currentPosition = new Vector3 (currentPosition.x + worldObjectIncAmount, currentPosition.y, currentPosition.z);

						int spawnChance = Random.Range (1, stoneChances + 1);

						if (spawnChance == 1) {
							GameObject spawn = stones [Random.Range (0, stones.Length)];

							spawnHere (currentPosition, spawn, worldObjectSphereRadius, false);

							yield return new WaitForSeconds (0.01f);
						}
						else {
							GameObject spawn = trees [Random.Range (0, trees.Length)];
							spawnHere (currentPostion, spawn, worldObjectSphereRadius, false);

							yield return new WaitForSeconds (0.01f);
						}
					}

					currentPosition = new Vector3 (worldObjectStartPos.x, worldObjectStartPos.y, worldObjectStartPos.z + worldObjectIncAmount);
				}
			}
		}
	}
}
