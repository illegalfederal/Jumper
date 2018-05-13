using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CameraMovement : MonoBehaviour {

	public GameObject player;
	Vector3 playerPos;
	new Vector3  camera;
	public float cameraZ;

	void Start () {
		player = GameObject.FindWithTag("Player");
		camera = transform.position;
		cameraZ = transform.position.z;
	}

	void Update () {

		playerPos = player.transform.position;
		transform.position = new Vector3(camera.x, camera.y, playerPos.z - Math.Abs(cameraZ));
	}
}
