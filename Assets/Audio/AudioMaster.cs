using UnityEngine;
using System.Collections;

public class AudioMaster : MonoBehaviour {
	public AudioSource whoLikesToParty;
	public AudioSource ost;
	public AudioSource hit;
	public AudioSource kaplja1;
	public AudioSource kaplja2;
	public AudioMaster audMast = null;
	// Use this for initialization
	void Start () {
		if (audMast == null)
		{
			DontDestroyOnLoad(gameObject);
			audMast = this;
		}
		else if (audMast != this)
		{
			Destroy(gameObject);
		}
		PlayOST();
	}

	public void PlayWhoLikesToParty(){
		whoLikesToParty.Play ();
		ost.Stop();
	}
	public void PlayOST(){
		ost.Play ();
		whoLikesToParty.Stop();
	}
	public void PlayHit(){
		hit.Play ();
	}
	public void PlayKaplja1(){
		kaplja1.Play ();
	}
	public void PlayKaplja2(){
		kaplja2.Play ();
	}
}