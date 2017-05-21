using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WireSistem : MonoBehaviour {
	public static WireSistem wireSistem;
	public static int score;
	public GameObject electron;
	//areas
	private int numberOfAreaTypes = 2;
	public GameObject Area1;
	public GameObject Area2;

	private const int offset = 10;

	private int number = 0;
	private static List<Area> areas = new List<Area>();

	// Use this for initialization
	void Awake () {
		wireSistem = this;
	}
	private void Start()
	{
		Screen.orientation = ScreenOrientation.LandscapeLeft;
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
	public void startGame()
	{
		areas.Add(new Area(null, null));
		areas.Add(new Area(null, null));
		createRandom();
		createRandom();
		createRandom();
		CanvasObj.canObj.gameObject.SetActive(false);
		PomoznaKamera.pomozna.gameObject.SetActive(false);
		StartCoroutine(startTheGame());
	}
	IEnumerator startTheGame()
	{
		yield return null;
		Instantiate(electron,SpawnPoint.point.transform.position, new Quaternion(0,0,0,0));

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
				newArea = Area2;
				break;
			default:
				print("napaka v switchu WireSistema");
				break;
		}
		Instantiate(newArea,new Vector2(number*offset,0),new Quaternion(0,0,0,0));
		number += 1;
	}
	public void end()
	{
		score = (int)ElectronMain.electron.transform.position.x;
		areas = new List<Area>();
		SceneManager.LoadScene(1);
		Score.score.setText(score);
	}
}

