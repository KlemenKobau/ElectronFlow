using UnityEngine;
using System.Collections;

public class KondenzScript : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<KondenzBehaviour> ().KondenzEnter ();
		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponent<KondenzBehaviour> ().KondenzExit ();
		}	
	}
}
