using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bGWallGenerator : MonoBehaviour {

	public GameObject wallPrefab;

	public GameObject bgPrefab;

	private GameObject mainCamera;

	private float mainCameraY;

	private float mainCameraYmax;

	private float wallPosY = 0;

	void Start () {

		mainCamera = GameObject.Find ("Main Camera");

		mainCameraY = mainCamera.transform.position.y;

		mainCameraYmax = mainCameraY;

		Debug.Log ("wallPosY" + wallPosY);
	}
	
	void Update () {

		mainCameraY = mainCamera.transform.position.y;

		if (mainCameraY > mainCameraYmax) {

			mainCameraYmax = mainCameraY;

		}

		if ( mainCameraYmax > wallPosY ) {
		
			BgWall ();

		}
	}

	void BgWall () {

		GameObject leftWall = Instantiate (wallPrefab) as GameObject;

		leftWall.transform.position = new Vector2 (-8.5f, wallPosY + 5f);

		GameObject rightWall = Instantiate (wallPrefab) as GameObject;

		rightWall.transform.position = new Vector2 (8.5f, wallPosY + 5f);

		GameObject bg = Instantiate (bgPrefab) as GameObject;

		bg.transform.position = new Vector2 (0, wallPosY + 5f);

		wallPosY += 5f;

	}
}
