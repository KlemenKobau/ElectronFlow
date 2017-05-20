using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllWires : MonoBehaviour {
	private List<GameObject> wires = new List<GameObject>();
	public Area here = null;

	// Use this for initialization
	void Start() {
		setWires();
	}
	void setWires()
	{
		foreach(Transform child in gameObject.transform)
		{
			wires.Add(child.gameObject);
		}
		here = new Area(gameObject,wires);
		WireSistem.wireSistem.addArea(here);
	}
	public Area getArea()
	{
		return here;
	}
}
public class Area
{
	public GameObject areaObject;
	public List<GameObject> wires;
	public int lokacija = 0;

	public Area(GameObject areaObject,List<GameObject> wires)
	{
		this.areaObject = areaObject;
		this.wires = wires;
	}
}
