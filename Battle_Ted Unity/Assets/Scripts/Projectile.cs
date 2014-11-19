using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public GameObject explosionPrefab;
	public string ignorePlayer;

	// Use this for initialization
	void Start () {
		//rigidbody2D.AddForce (Vector2.right * 10f, ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag != ignorePlayer) {
			Rigidbody2D explosionInstance;
			explosionInstance = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as Rigidbody2D;
			DestroyObject (this.gameObject);
		}
	}
}
