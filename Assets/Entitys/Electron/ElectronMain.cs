using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronMain : MonoBehaviour {
	public static ElectronMain electron;
	private Vector2 electronPosition;
	private float speed = 4f;
	private const float lambda = 0.01f;
	public Sprite normalno = null;
	public Sprite modr = null;

	private Area target;
	private Vector2 targetPosition;
	private bool invunerable = false;
	//invunerability
	private const float timeOfInv = 1f;
	private float cooldown = 0.5f;

	private float cooldownTimer;

	private void Start()
	{
		electron = this;
		target = WireSistem.wireSistem.getTargetArea();
		targetPosition = target.wires[0].transform.position;
		StartCoroutine(getInvunerableFirst(0));
	}

	// Update is called once per frame
	void FixedUpdate () {
		speed += 0.1f * Time.deltaTime;
		cooldown /= (2 * Time.deltaTime);
		if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine(getInvunerable(cooldownTimer));
		}
		if(cooldownTimer > 0)
		{
			cooldownTimer -= Time.deltaTime;
		}
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
		if (other.tag.Equals("Empty Space") && !invunerable)
		{
			WireSistem.wireSistem.end();
		}
	}
	private IEnumerator getInvunerable(float cooldown)
	{
		if(cooldownTimer <= 0)
		{
			invunerable = true;
			gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = modr;
			yield return new WaitForSeconds(timeOfInv);
			invunerable = false;
			gameObject.transform.GetChild (0).gameObject.GetComponent<SpriteRenderer> ().sprite = normalno;
			cooldownTimer = cooldown;
		}
		else
		{
			yield return null;
		}
	}
	private IEnumerator getInvunerableFirst(float cooldown)
	{
		if(cooldownTimer <= 0)
		{
			invunerable = true;
			yield return new WaitForSeconds(timeOfInv);
			invunerable = false;
			cooldownTimer = cooldown;
		}
		else
		{
			yield return null;
		}
	}
}
 