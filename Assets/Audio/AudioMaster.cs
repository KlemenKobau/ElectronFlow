using UnityEngine;
using System.Collections;

public class AudioMaster : MonoBehaviour {
	public AudioSource whoLikesToParty;
	public AudioSource ost;
	public AudioSource hit;
	public AudioSource kaplja1;
	public AudioSource kaplja2;
	// Use this for initialization
	void Start () {
		PlayWhoLikesToParty ();
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