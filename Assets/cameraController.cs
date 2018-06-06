using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

	GameObject unityChan;

	float mainCameraY;

	float unityChanY;

	void Start () {

		unityChan = GameObject.FindGameObjectWithTag ("UnityChan");

		mainCameraY = this.transform.position.y;

	}

	void Update () {

		unityChanY = unityChan.transform.position.y;

		if (unityChanY > mainCameraY + 1.315f) {

			this.transform.position = new Vector3 (0, unityChanY + 1.315f, -10);

		}
	}
}
