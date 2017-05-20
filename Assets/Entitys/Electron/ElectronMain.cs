using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronMain : MonoBehaviour {
	private Rigidbody2D electronRigidbody = null;
	private Vector2 electronPosition;
	private float speed = 0.1f;

	private Vector2 target = new Vector2(100,100);

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
