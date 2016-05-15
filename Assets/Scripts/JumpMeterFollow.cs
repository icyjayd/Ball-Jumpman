using UnityEngine;
using System.Collections;

public class JumpMeterFollow : MonoBehaviour {

	public PlayerController target;
	// Use this for initialization


	void Start(){
		transform.position = new Vector3 (transform.position.x, (transform.position.y + Screen.height * .025f), transform.position.z);
	}
	// Update is called once per frame
	void FixedUpdate () {
		TextMesh textObject = GetComponent<TextMesh> ();
		if (target.bounceTime <= target.bounceMax) {
			textObject.text = target.bounceTime.ToString ("F2");
		} else {
			textObject.text = "READY";
		}
	}
}
