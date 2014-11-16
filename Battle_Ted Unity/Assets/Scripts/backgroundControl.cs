using UnityEngine;
using System.Collections;

public class backgroundControl : MonoBehaviour {
	[HideInInspector]
	public float cameraX;
	public float X;
	public float W;
	private float W2;
	private float score = 0;
	private float score2 = 0;
	public int winScore = 5;
	public string direction;
	private float magnitude;
	public GameObject leftplayer;
	public GameObject rightplayer;
	// Use this for initialization
	void Start () {
		camera.rect = new Rect(X,0,W,1);
		magnitude = 0.5f / winScore;
		cameraX = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		score2 = -rightplayer.GetComponent<PlayerController2>().hazardhit + leftplayer.GetComponent<PlayerController2>().hazardhit;
		score = Mathf.Lerp (score, score2, .01f);
		if (direction == "Left") {
			W = 0.5f + magnitude*score;
		} else {
			W = 0.5f - magnitude*score;
			X = magnitude*score + 0.5f;
			cameraX = (magnitude*score)*70.0f;
		}
		camera.rect = new Rect(X,0,W,1);
		if (Mathf.Abs(score) >= winScore) {
			Application.LoadLevel("end");
		}

	}
}

