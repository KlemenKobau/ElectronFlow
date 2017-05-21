using UnityEngine;
using System.Collections;

public class BcgAnimator : MonoBehaviour {

	//Parametri: Alpha cutoff,
	public Material bcgMat;
	public float speed;
	public Texture[] textures;
	public Rigidbody2D playerRoby;

	//private Color oldColor = new Vector4(0f, 105f/255f, 120f/255f, 1f);
	private Vector2 offset;
	private int selectedTex = 1;

	// Use this for initialization
	void Start () {
		bcgMat.SetTexture ("_MainTex", textures [0]);
		InvokeRepeating ("Transition", 1f, 10f);
	}

	void Update(){
		offset += new Vector2(-playerRoby.velocity.x * speed, -playerRoby.velocity.y*speed);
		bcgMat.SetTextureOffset("_MainTex", offset);
	}

	public void Transition()
	{
		StartCoroutine (ColorLerp());
	}
	IEnumerator ColorLerp(float increment = 0.2f){
		while (increment < 1f) {
			bcgMat.SetFloat ("_Cutoff", increment);
			increment += 0.005f;
			yield return null;
		}
		yield return new WaitForSeconds (0.2f);
		bcgMat.SetTexture ("_MainTex", textures [selectedTex]);
		while (increment > 0.2f) {
			bcgMat.SetFloat ("_Cutoff", increment);
			increment -= 0.005f;
			yield return null;
		}
		if (selectedTex >= 1) {
			selectedTex = 0;
		} else {
			selectedTex++;
		}
		yield break;
	}
}
