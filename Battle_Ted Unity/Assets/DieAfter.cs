using UnityEngine;
using System.Collections;

public class DieAfter : MonoBehaviour {
	public float time;
	private float count;
	// Use this for initialization
	void Start () {
		count = time;
	}
	
	// Update is called once per frame
	void Update () {
		count -= Time.deltaTime;
		if (count < 0) { 
						DestroyObject (this.gameObject);
				}
	}
}
