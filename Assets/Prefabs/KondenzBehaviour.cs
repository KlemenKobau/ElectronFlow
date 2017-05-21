using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(ConstantForce2D))]

public class KondenzBehaviour : MonoBehaviour {

	public float kondenzForce;
	public float tapForce;

	private Rigidbody2D rb;
	private ConstantForce2D cf;

	void Start(){
		gameObject.tag = "Player";
		rb = GetComponent<Rigidbody2D> ();
		cf = GetComponent<ConstantForce2D> ();
		rb.isKinematic = true;
		cf.force = Vector2.zero;
	}

	public void KondenzEnter(){
		rb.isKinematic = false;
		cf.force = new Vector2(-kondenzForce,0f);
		StartCoroutine (KondenzJumping ());
	}
	public void KondenzExit(){
		rb.isKinematic = true;
		cf.force = Vector2.zero;
	}

	IEnumerator KondenzJumping(){
		while (rb.isKinematic == false) {
			if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)||Input.GetAxis("Fire1")>0f) {
				rb.AddForce (new Vector2 (tapForce, 0f), ForceMode2D.Impulse);
					yield return new WaitForSeconds (0.1f);
			}
			yield return null;
		}
		yield break;
	}
}
