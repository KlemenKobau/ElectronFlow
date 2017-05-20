using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour {

	public static SpawnPoint point = null;
	
	// Use this for initialization
	void Awake () {
		point = this;
	}
}
