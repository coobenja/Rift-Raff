using UnityEngine;
using System.Collections;

public class backgroundControl : MonoBehaviour {
	public float X;
	public float W;
	public string direction;
	public float magnitude;
	//public GameObject leftplayer;
	//public GameObject rightplayer;
	// Use this for initialization
	void Start () {
		camera.rect = new Rect(X,0,W,1);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			if (direction == "Left") {
				W = W + magnitude;
			} else {
				W = W - magnitude;
				X = magnitude + X;
			}
			camera.rect = new Rect(X,0,W,1);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			if (direction == "Left") {
				W = W - magnitude;
			} else {
				W = W + magnitude;
				X = -magnitude + X;
			}
			camera.rect = new Rect(X,0,W,1);
		}
	}
}
