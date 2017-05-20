using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireSistem : MonoBehaviour {
	public static WireSistem wireSistem;
	private static List<GameObject> wires = new List<GameObject>();

	// Use this for initialization
	void Awake () {
		wireSistem = this;
	}
	private void Start()
	{
		StartCoroutine(giveFirstTarget());
	}
	public void addWires(List<GameObject> area)
	{
		foreach (GameObject wire in area)
		{
			wires.Add(wire);
		}
	}
	public GameObject getTarget()
	{
		GameObject target = wires[0];
		wires.RemoveAt(0);
		return target;
	}
	IEnumerator giveFirstTarget()
	{
		yield return null;
		ElectronMain.electron.giveFirstTarget(getTarget());
	}
}
