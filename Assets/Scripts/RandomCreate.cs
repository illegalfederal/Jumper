using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCreate : MonoBehaviour {

	public GameObject[] spawn;
	public Transform spawner;
	int randomInt;
	float randomX;
	public float aralik, scale;
	PlayerMove player;

	private void Start()
	{
		player = GameObject.Find("Player").GetComponent<PlayerMove>();

		aralik = 5f;
		scale = spawner.position.z - aralik;

		for(int i=1; i<=15; i++) { SpawnRandom(); }
		
	}

	void Update()
	{
		if (player.yerde==true)
		{
			SpawnRandom();
		}
	}

	void SpawnRandom()
	{
		SpawnDeger();

		if (randomX % 3 < 0.2){Instantiate(spawn[randomInt], spawner.position, spawner.rotation);}
		else{Instantiate(spawn[randomInt+3], spawner.position, spawner.rotation);}
	}

	void SpawnDeger()
	{
		randomX = Random.Range(-17f, 8f);
		randomInt = Random.Range(0, spawn.Length -3);
		scale = scale + spawn[randomInt].transform.localScale.z + aralik ;
		spawner.position = new Vector3(randomX, 0, scale);
	}
}

