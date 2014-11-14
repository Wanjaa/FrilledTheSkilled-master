using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
	public float speed = 1.0f;
	public float rayLength = 1.5f;
	public float jumpSpeed = 15.0f;

	private LayerMask mask = 8;

	public bool isGrounded()
	{
		Vector2 myPos = new Vector2 (this.transform.position.x, this.transform.position.y); // Jump Fixierung 
		return Physics2D.Raycast(myPos, -Vector2.up, rayLength, 1<<mask.value);
	}
	
	void FixedUpdate(){

		if (Input.GetKey (KeyCode.A)) {
			this.transform.rigidbody2D.AddForce (new Vector2 (-speed, 0)); // Der Spieler bewegt sich nach Links
		} else if (Input.GetKey (KeyCode.D)) {
			this.transform.rigidbody2D.AddForce (new Vector2 (speed, 0)); // Der Spieler bewegt sich nach Rechts 
		}
		
		if (isGrounded ()) {
			if (Input.GetKey (KeyCode.Space) || Input.GetKey ("w")) { // Der Spieler kann mit dem Code Springen
				//Dann verändert sich der Y Wert des Spielers
				this.rigidbody2D.velocity = new Vector3 (0, jumpSpeed, 0);
			}
		}
	}


}