using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
	Score score;

	public bool yerde, basla,yon, pressed;
	public float ziplama, dusus;
	public float maxY;
	public float ileri;
	public float yonHiz;
	Vector3  mousePos;
	Rigidbody rb;
	GameObject retry;
	Text scoreText;

	void Start()
	{
		retry = GameObject.FindGameObjectWithTag("Lose");
		rb = GetComponent<Rigidbody>();
		score = gameObject.GetComponent<Score>();
		scoreText = GameObject.Find("ScoreText").GetComponent<Text>();

		retry.SetActive(false);
		yerde = false;
		ziplama = 20f;
		dusus = 10f;
		maxY = 5f;
		ileri = 20f;
		yonHiz = 5f;
		basla = false;
		rb.isKinematic = true;
		yon = false;

	}

	void Update()
	{
		if (Input.GetMouseButtonDown(0)) basla = true; 

		if (basla == true) {
			rb.isKinematic = false;
			Jump();

			if (yon == true) Yon();
		}

		Dusus();				
	}

	void Dusus()
	{
		if (transform.position.y < -5)
		{

			retry.SetActive(true);
			scoreText.text = "Score: " + score.skor;

		}
	}

	void Yon()
	{		
		if (Input.GetMouseButton(0))
		{
			mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

			transform.position = new Vector3(transform.position.x + mousePos.x * yonHiz, transform.position.y, transform.position.z);

		}
	}

	void Jump()
	{		
		if (transform.position.y >= maxY)
		{		
			rb.velocity = new Vector3(0, -dusus, ileri);
		}

		if (yerde == true)
		{
			rb.velocity = new Vector3(0, ziplama, ileri);
			yerde = false;
		}
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "zemin"|| col.gameObject.tag == "KirmiziZemin"|| col.gameObject.tag == "MaviZemin" || col.gameObject.tag == "YesilZemin")
		{
			yerde = true;
			yon = true;			
		}
	}
}