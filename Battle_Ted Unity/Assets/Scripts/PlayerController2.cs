using UnityEngine;
using System.Collections;

public class PlayerController2 : MonoBehaviour {

	[HideInInspector]
	public bool jump = false;
	[HideInInspector]
	public int hazardhit = 0;
	public string direction;
	private bool explosionhit = false;
	public float explosiontime = 1.8f;
	private float explosioncount;
	public int health = 5;


	public string moveIn;
	public string jumpIn;
	public string aimXIn;
	public string aimYIn;

	
	public float groundMoveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	public float airMoveForce = 50f;
	private float moveForce;

	public GameObject arm;

	private bool grounded = false;
	private Transform groundCheck;
	private Transform targetPosition;

	private GameObject leftCam;// = GameObject.Find("BackgroundCameraLeft");
	private GameObject rightCam;// = GameObject.Find("BackgroundCameraRight");
	

	// Use this for initialization
	void Awake () {
		// Setting up references.
		leftCam = GameObject.Find("BackgroundCameraLeft");
		rightCam = GameObject.Find("BackgroundCameraRight");
		explosioncount = explosiontime;
		groundCheck = transform.Find ("groundCheck");

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

		if (grounded)
						moveForce = groundMoveForce;
				else 
						moveForce = airMoveForce;

		//rigidbody2D.AddForce(Vector2.right * h * moveForce);

		// If the player is changing direction (h has a different sign to velocity.x) or hasn't reached maxSpeed yet...
		if(h * rigidbody2D.velocity.x < maxSpeed && !explosionhit)
			// ... add a force to the player.
			rigidbody2D.AddForce(Vector2.right * h * moveForce);

		//Limit player speed to max
		if (!explosionhit && grounded) {
						if (Mathf.Abs (rigidbody2D.velocity.x) > maxSpeed)
				// ... set the player's velocity to the maxSpeed in the x axis.
								rigidbody2D.velocity = new Vector2 (Mathf.Sign (rigidbody2D.velocity.x) * maxSpeed, rigidbody2D.velocity.y);
				} else {
						explosioncount -= Time.deltaTime;
						if (explosioncount < 0) {
								explosionhit = false;
								explosioncount = explosiontime;
						}
				}

		if(jump)
		{
			// Add a vertical force to the player.
			rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
			jump = false;
		}

	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Hazard") {
			hazardhit ++;
			//leftCam.GetComponent<backgroundControl>().takeDamage("left");
		}
		if (coll.gameObject.tag == "Explosion") {
			explosionhit = true;
			explosioncount = explosiontime;

		}
		if (coll.gameObject.tag == "Ground" && rigidbody2D.velocity.sqrMagnitude > 0) {
			health -= 1;
			Debug.Log ("Ouch");
		}
	}

	/*void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Explosion") {
			explosionhit = true;
		}
	}*/
}
