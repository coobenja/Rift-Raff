using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

	[HideInInspector]
	public bool jump = false;
	[HideInInspector]
	public bool hazardhit = false;

	public string moveIn;
	public string jumpIn;
	public string aimXIn;
	public string aimYIn;
	public string triggerIn;
	
	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;

	public GameObject arm;

	private bool grounded = false;
	private Transform groundCheck;
	private Transform firePoint;
	private Transform targetPosition;
	

	// Use this for initialization
	void Awake () {
		// Setting up references.
		groundCheck = transform.Find ("groundCheck");
		firePoint = transform.Find ("firePoint");
	}

	void Update() {
		// The player is grounded if a linecast to the groundcheck position hits anything on the ground layer.
		grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));  


		// If the jump button is pressed and the player is grounded then the player should jump.
		if (Input.GetButtonDown (jumpIn) && grounded) {
			jump = true;
		}


		// Smoothly rotates towards target 
		//var targetPoint = targetPosition.transform.position;
		//var targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
		//transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0);    
	}

	// Update is called once per frame
	void FixedUpdate () {
	
		float h = Input.GetAxis (moveIn);

		rigidbody2D.AddForce(Vector2.right * h * moveForce);

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);

		//Limit player speed to max
		if(Mathf.Abs(rigidbody2D.velocity.x) > maxSpeed)
			// ... set the player's velocity to the maxSpeed in the x axis.
			rigidbody2D.velocity = new Vector2(Mathf.Sign(rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);

		if(jump)
		{
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}

		//Shooting Projectile
		/*if (Input.GetAxis (triggerIn) > 0) {
			Instantiate(Projectile, firePoint, Quaternion.identity);
		}*/

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Hazard") {
			hazardhit = true;
			print("hit");
		}
		
	}
}
