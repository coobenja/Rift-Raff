using UnityEngine;
using System.Collections;

public class HammerPickUp : MonoBehaviour {

	public float damageTime = 4f;
	public float torque = 40f;

	//public GameObject forceBallPrefab;
	//public GameObject explosionPrefab;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (damageTime > 0) 
		{
			damageTime -= Time.deltaTime;
			rigidbody2D.AddTorque(30f);
			gameObject.tag = "Hazard";
			GetComponent<SpriteRenderer>().color = Color.red;
			//Physics2D.IgnoreCollision(forceBallPrefab.collider2D, collider2D, true);
			//Physics2D.IgnoreCollision(explosionPrefab.collider2D, collider2D, true);
		}
		else
		{
			gameObject.tag = "Weapon";
			GetComponent<SpriteRenderer>().color = Color.grey;
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player" && damageTime <= 0f) {
			//Object.Destroy(this.gameObject);
		}
	}
}
