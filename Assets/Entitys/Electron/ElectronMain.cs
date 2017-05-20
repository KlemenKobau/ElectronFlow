using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronMain : MonoBehaviour {
	public static ElectronMain electron;
	private Vector2 electronPosition;
	private float speed = 2f;
	private const float lambda = 0.01f;

	private GameObject target;
	private Vector2 targetPosition;

	private void Start()
	{
		electron = this;
	}

	// Update is called once per frame
	void FixedUpdate () {
		electronPosition = gameObject.transform.position;
		gameObject.transform.position = Vector2.MoveTowards(electronPosition, targetPosition,speed*Time.deltaTime);
		if(Vector2.Distance(electronPosition,targetPosition) < lambda)
		{
			target = WireSistem.wireSistem.getTarget();
			targetPosition = target.transform.position;
		}
	}
	public void giveFirstTarget(GameObject target)
	{
		this.target = target;
		targetPosition = target.transform.position;
		print(target);
	}
}
 