using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllWires : MonoBehaviour {
	private List<GameObject> wires = new List<GameObject>();

	// Use this for initialization
	void Start () {
		setWires();
	}
	void setWires()
	{
		foreach(Transform child in gameObject.transform)
		{
			wires.Add(child.gameObject);
		}
	}
	public List<GameObject> getWires()
	{
		return wires;
	}
	private void giveWires()
	{
		WireSistem.wireSistem.addWires(wires);
	}
}
