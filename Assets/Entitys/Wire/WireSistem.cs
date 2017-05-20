using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSistem : MonoBehaviour {
	public static WireSistem wireSistem;
	private static List<GameObject> wires = new List<GameObject>();

	// Use this for initialization
	void Start () {
		wireSistem = this;
	}
	public void addWires(List<GameObject> area)
	{
		foreach (GameObject wire in area)
		{
			wires.Add(wire);
		}
	}
}
