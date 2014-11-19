using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float speed = 1.0f;
	public float rayLength = 1.5f;
	public float jumpSpeed = 15.0f;
	public float Slidespeed = 1f;
	public float Resetspeed;
	public AnimationCurve PlayerSpeed;

	private LayerMask mask = 8;
	private bool canGlide;

	public bool isGrounded()
	{
		Vector2 myPos = new Vector2 (this.transform.position.x, this.transform.position.y); // Jump Fixierung 
		return Physics2D.Raycast(myPos, -Vector2.up, rayLength, 1<<mask.value);
	}

	void Start()
	{
		Resetspeed = speed;
		}
	
	void FixedUpdate(){

		if (Input.GetKey (KeyCode.A)) {
						this.transform.rigidbody2D.AddForce (new Vector2 (-speed, 0)); // Der Spieler bewegt sich nach Links
				} else if (Input.GetKey (KeyCode.D)) {
						this.transform.rigidbody2D.AddForce (new Vector2 (speed, 0)); // Der Spieler bewegt sich nach Rechts 
		} else if(isGrounded()){
			rigidbody2D.velocity = Vector2.zero;
		}

		if (isGrounded () == false && Input.GetKey (KeyCode.Space)) {
			rigidbody2D.gravityScale = 1f;
			speed = Slidespeed;
			Debug.Log("Gleiten");
				} else {
			rigidbody2D.gravityScale = 2f;
			Debug.Log("Kein Gleiten");
			speed = Resetspeed;
		}

		
		if (isGrounded ()) {

						if (Input.GetKey (KeyCode.Space) || Input.GetKey ("w")) { // Der Spieler kann mit dem Code Springen
								//Dann verändert sich der Y Wert des Spielers
								this.rigidbody2D.velocity = new Vector3 (0, jumpSpeed, 0);
					}
			} 
	}


}