using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformChange : MonoBehaviour {

	public Material normal;

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{

				this.GetComponent<MeshRenderer>().material = normal;
				this.gameObject.tag = "zemin";

		}
	}

}
