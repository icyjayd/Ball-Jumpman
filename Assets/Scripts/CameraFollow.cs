using UnityEngine;
using System.Collections;
using System;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public Rigidbody2D targetRB;
	public PlayerController targetPC ;
	Camera mycam;

	private bool goingRight = true;

	void Start () {
		mycam = GetComponent<Camera> ();
		mycam.orthographicSize = (Screen.height/10f)/4f;
		transform.position = new Vector3 (target.position.x, mycam.orthographicSize, -10); 

	}

	
	void Update () {
		Vector3 screenPos = mycam.WorldToScreenPoint(target.position);
		float speed = targetRB.velocity.x;
		//float jumpspeed = targetRB.velocity.y;
		mycam.orthographicSize = (Screen.height/10f)/4f;
		float discrepancy = Screen.width * .005f;

		if (speed != 0 & speed == Math.Abs (speed)) 
		{
			goingRight = true;
		} 
		else 
		{
			goingRight = false;
		}


		//gives the a discrepancy when changing directions, follows only on the x axis
		if (goingRight == true & screenPos.x >= Screen.width * .6f) 
				{
					transform.position = Vector3.Lerp (new Vector3(transform.position.x, mycam.orthographicSize, 0), new Vector3(target.position.x - discrepancy, mycam.orthographicSize, 0), 1f) + new Vector3(0, 0, -10); 
				}
				else if(goingRight == false & screenPos.x <= Screen.width * .4f)
				{
					transform.position = Vector3.Lerp (new Vector3(transform.position.x, mycam.orthographicSize, 0), new Vector3(target.position.x + discrepancy, mycam.orthographicSize, 0), 1f) + new Vector3(0, 0, -10); 
				}
			}
	
	}

