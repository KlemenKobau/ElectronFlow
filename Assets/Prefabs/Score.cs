using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
	public static Score score = null;
	// Use this for initialization
	void Start () {
		score = this;
	}
	public void setText(int score)
	{
		gameObject.GetComponent<Text>().text = "Score: " + score;
	}
}
