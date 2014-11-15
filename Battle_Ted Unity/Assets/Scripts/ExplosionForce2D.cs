﻿using UnityEngine;
using System.Collections;

public class ExplosionForce2D : MonoBehaviour
{
	public float Power;
	public float Radius;
	
		// Use this for initialization
		void Start ()
		{
	
		}

		void OnCollisionEnter2D(Collision2D coll) {
		//print ("hit");
			if (coll.gameObject.tag == "Explosion") {
				AddExplosionForce(this.rigidbody2D, Power * 100, coll.transform.position, Radius);
			}
		}

		public static void AddExplosionForce (Rigidbody2D body, float expForce, Vector3 expPosition, float expRadius)
		{
				var dir = (body.transform.position - expPosition);
				float calc = 1 - (dir.magnitude / expRadius);
				if (calc <= 0) {
						calc = 0;		
				}
				body.AddForce (dir.normalized * expForce * calc);
		}


}
