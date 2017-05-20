using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronMain : MonoBehaviour {
	public static ElectronMain electron;
	private Vector2 electronPosition;
	private float speed = 4f;
	private const float lambda = 0.01f;

	private Area target;
	private Vector2 targetPosition;

	private void Start()
	{
		electron = this;
		target = WireSistem.wireSistem.getTargetArea();
		targetPosition = target.wires[0].transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		electronPosition = gameObject.transform.position;
		gameObject.transform.position = Vector2.MoveTowards(electronPosition, targetPosition,speed*Time.deltaTime);
		if(Vector2.Distance(electronPosition,targetPosition) < lambda)
		{
			if (target.lokacija != target.wires.Count)
			{
				targetPosition = target.wires[target.lokacija].transform.position;
				target.lokacija++;
			}
			else if(target.lokacija == target.wires.Count)
			{
				target = WireSistem.wireSistem.getTargetArea();
				targetPosition = target.wires[0].transform.position;
			}
			else
			{
				print("napaka v elektronu fixed update");
			}
		}
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag.Equals("Empty Space"))
		{
			WireSistem.wireSistem.end();
		}
	}
}
 