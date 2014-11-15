using UnityEngine;
using System.Collections;

public class ExplosionForce2D : MonoBehaviour
{
	public float Power = 15;
	
		// Use this for initialization
		void Start ()
		{
	
		}

		void OnCollisionEnter2D(Collision2D coll) {
		//print ("hit");
			if (coll.gameObject.tag == "Explosion") {
				AddExplosionForce(this.rigidbody2D, Power * 100, coll.transform.position);
			}
		}

		public static void AddExplosionForce (Rigidbody2D body, float expForce, Vector3 expPosition)
		{
				var dir = (body.transform.position - expPosition);
				body.AddForce (dir.normalized * expForce);
		}


}
