using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {
	public GameObject Player;
	public GameObject cam;
	public Vector3 offset;
	
	// Use this for initialization
	void Start () {
		cam = GameObject.Find("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		cam.transform.position = Player.transform.position + offset;
	}
}
