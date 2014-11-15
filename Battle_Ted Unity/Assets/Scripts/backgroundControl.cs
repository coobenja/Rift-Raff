using UnityEngine;
using System.Collections;

public class backgroundControl : MonoBehaviour {
	public float X;
	public float W;
	private float score = 0;
	public string direction;
	public float magnitude;
	public GameObject leftplayer;
	public GameObject rightplayer;
	private bool done = true;
	// Use this for initialization
	void Start () {
		camera.rect = new Rect(X,0,W,1);
	}
	
	// Update is called once per frame
	void Update () {
		score = -rightplayer.GetComponent<PlayerController2>().hazardhit + leftplayer.GetComponent<PlayerController2>().hazardhit;
		if (direction == "Left") {
			W = 0.5f + magnitude*score;
		} else {
			W = 0.5f - magnitude*score;
			X = magnitude*score + 0.5f;
		}
		print (W);
		camera.rect = new Rect(X,0,W,1);

		/*if (rightplayer.GetComponent<PlayerController2> ().hazardhit) {
			takeDamage("right");
		}
		if (leftplayer.GetComponent<PlayerController2> ().hazardhit) {
			done = takeDamage("left");
		}
		if (done)
						print (done);//leftplayer.GetComponent<PlayerController2> ().hazardhit = false;
		//print (done);*/
	}

	/*void takeDamage(string dir) {
		//score = rightplayer.GetComponent<PlayerController2>().hazardhit - leftplayer.GetComponent<PlayerController2>().hazardhit;
		if (dir == "right") {
			if (direction == "Left") {
				W = W + magnitude;
			} else {
				W = W - magnitude;
				X = magnitude + X;
			}
			camera.rect = new Rect(X,0,W,1);
			print ("hit");
		}
		if (dir == "left") {
			if (direction == "Left") {
				W = W - magnitude;
			} else {
				W = W + magnitude;
				X = -magnitude + X;
			}
			camera.rect = new Rect(X,0,W,1);
			print ("hit");
		}
	}*/
}

