using UnityEngine;
using System.Collections;

public class endscreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("start")) {
			Application.LoadLevel("Opening_Menu");
		}
	}
}
