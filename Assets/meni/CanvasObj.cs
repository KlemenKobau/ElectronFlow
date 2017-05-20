using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasObj : MonoBehaviour {
	public static CanvasObj canObj = null;
	// Use this for initialization
	void Start () {
		canObj = this;
	}
}
