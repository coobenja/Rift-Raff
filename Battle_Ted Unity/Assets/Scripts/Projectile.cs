using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		rigidbody2D.AddForce (new Vector2(40f, 0f), ForceMode2D.Impulse);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
