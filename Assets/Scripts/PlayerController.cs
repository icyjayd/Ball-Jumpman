using UnityEngine;
using System.Collections;
using System;
public class PlayerController : MonoBehaviour {

	public float acceleration; //determine player's acceleration	
	public float MaxSpeed;//determine maximum speed
	public float strength; //determine jump strength


	public float bounceTime;
	public float bounceMax;
	private Rigidbody2D rb;

	void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();

	
	}
	

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Jump");
		float velocity = rb.velocity.x;
	
		Vector2 movement = new Vector2 (moveHorizontal, 0);
		Vector2 movementJump = new Vector2 (0, moveVertical);
		
		if (velocity <= MaxSpeed & velocity >= MaxSpeed *-1)
		{
			rb.AddForce (movement * acceleration);
		}




		if (bounceTime >= bounceMax & (Input.GetButton("Jump"))) {	
			rb.AddForce (movementJump * strength, ForceMode2D.Impulse);
			bounceTime = 0;
		}

		bounceTime = bounceTime + 1 * Time.deltaTime;


	
	}
}		