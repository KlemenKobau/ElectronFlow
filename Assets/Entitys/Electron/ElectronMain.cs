using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronMain : MonoBehaviour {
	private Vector2 electronPosition;
	private float speed = 2f;

	private Vector2 target = new Vector2(100,100);

	// Update is called once per frame
	void FixedUpdate () {
		electronPosition = gameObject.transform.position;
		gameObject.transform.position = Vector2.MoveTowards(electronPosition, target,speed*Time.deltaTime);
	}
}
