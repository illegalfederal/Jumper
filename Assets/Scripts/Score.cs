using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public bool[] renkler = new bool[3];
	public float skor;

	Image kirmizi, yesil, mavi;
	Text ScoreText, HUDskor;
	Canvas ScoreCanvas;

	private void Start()
	{
		RenkSifirla();

		kirmizi = GameObject.Find("KirmiziUI").GetComponent<Image>();
		yesil = GameObject.Find("YesilUI").GetComponent<Image>();
		mavi = GameObject.Find("MaviUI").GetComponent<Image>();

		ScoreText = GameObject.Find("ScoreText").GetComponent<Text>();
		HUDskor = GameObject.Find("Skor").GetComponent<Text>();
		ScoreCanvas = GameObject.Find("ScoreCanvas").GetComponent<Canvas>();

		kirmizi.enabled = false;
		yesil.enabled = false;
		mavi.enabled = false;
		ScoreText.enabled = false;
		skor = 0;
	}

	private void Update()
	{

		RenkUI();

		HUDskor.text = skor + "";

		ScoreCanvas.transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);

		if (ScoreText.enabled == true){ScoreText.CrossFadeAlpha(0.0f, 1f, true);}


	}

	public void RenkSifirla()
	{
		renkler[0] = renkler[1] = renkler[2] = false;
		
	}

	public bool RenkPuani()
	{
		if (renkler[0] == true && renkler[1] == true && renkler[2] == true)
		{

			RenkSifirla();
			return true;

		}
		return false;
	}

	private void RenkUI()
	{
		if (renkler[0] == true) kirmizi.enabled = true;
		else kirmizi.enabled = false;

		if (renkler[1] == true) yesil.enabled = true;
		else yesil.enabled = false;

		if (renkler[2] == true) mavi.enabled = true;
		else mavi.enabled = false;
	}

	void OnCollisionEnter(Collision col)
	{

		if (col.gameObject.tag == "zemin")
		{
			skor++;
			if (RenkPuani() == true) { skor = skor + 6; ScoreText.enabled = true; ScoreText.CrossFadeAlpha(1.0f, 0f, true); RenkSifirla(); }
		}

		if (col.gameObject.tag == "KirmiziZemin")
		{
			if (RenkPuani() == true) { skor = skor + 6; ScoreText.enabled = true; ScoreText.CrossFadeAlpha(1.0f, 0f, true); RenkSifirla(); }

			if (renkler[0] == true) renkler[0] = false;
			else renkler[0] = true;
		}

		if (col.gameObject.tag == "YesilZemin")
		{
			if (RenkPuani() == true) { skor = skor + 6; ScoreText.enabled = true; ScoreText.CrossFadeAlpha(1.0f, 0f, true); RenkSifirla(); }

			if (renkler[1] == true) renkler[1] = false;
			else renkler[1] = true;
		}

		if (col.gameObject.tag == "MaviZemin")
		{
			if (RenkPuani() == true) { skor = skor + 6; ScoreText.enabled = true; ScoreText.CrossFadeAlpha(1.0f, 0f, true); RenkSifirla(); }

			if (renkler[2] == true) renkler[2] = false;
			else renkler[2] = true;
		}
	}
}
