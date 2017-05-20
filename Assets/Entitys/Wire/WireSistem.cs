using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSistem : MonoBehaviour {
	public static WireSistem wireSistem;
	public GameObject electron;
	//areas
	private int numberOfAreaTypes = 1;
	public GameObject Area1;
	//public GameObject Area2;
	
	private int areaLimit = 5;

	private const int offset = 10;
	private Vector2 startingPosition = new Vector2(0, 0);

	private int number = 0;
	private static List<Area> areas = new List<Area>();

	// Use this for initialization
	void Awake () {
		wireSistem = this;
		areas.Add(new Area(null, null));
		areas.Add(new Area(null, null));
		createRandom();
		createRandom();
		createRandom();
	}
	private void Start()
	{
		StartCoroutine(startTheGame());
	}
	public void addArea(Area that)
	{
		areas.Add(that);
	}
	public Area getTargetArea()
	{
		Area target = areas[3];
		Destroy(areas[0].areaObject);
		areas.RemoveAt(0);
		createRandom();
		return target;
	}
	IEnumerator startTheGame()
	{
		yield return null;
		Instantiate(electron,areas[3].wires[0].transform.position, new Quaternion(0,0,0,0));
	}
	private void createRandom()
	{
		int rand = Random.Range(1, numberOfAreaTypes+1);
		GameObject newArea = null;

		switch (rand)
		{
			case 1:
				newArea = Area1;
				break;
			case 2:
				//newArea = Area2;
				break;
			default:
				print("napaka v switchu WireSistema");
				break;
		}
		Instantiate(newArea,new Vector2(number*offset,0),new Quaternion(0,0,0,0));
		number += 1;
	}
}

