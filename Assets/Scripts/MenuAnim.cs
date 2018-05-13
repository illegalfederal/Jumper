using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnim : MonoBehaviour {


	Rigidbody rb;
	float PosY;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		PosY = transform.position.y;

	}

	void Update () {

		if (transform.position.y <= PosY)
		{
			
			rb.velocity = Vector3.up * (10f /Time.deltaTime);
		}

		if (transform.position.y >= PosY + 150f)
		{
			rb.velocity = Vector3.down * (5f / Time.deltaTime);
		}
	}
}
