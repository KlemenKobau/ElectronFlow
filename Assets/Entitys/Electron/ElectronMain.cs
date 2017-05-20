using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronMain : MonoBehaviour {
	private Rigidbody2D electronRigidbody = null;
	private Vector2 electronPosition;
	private float speed = 3.5f;
	//comment
	private Vector2 target;

	// Use this for initialization
	void Start () {
		electronRigidbody = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		electronPosition = gameObject.transform.position;
		gameObject.transform.position = Vector2.MoveTowards(electronPosition, target,speed);
	}
}
