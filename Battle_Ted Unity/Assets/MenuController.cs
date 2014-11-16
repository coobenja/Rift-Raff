using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour {
	private Animator animator;
	private int page;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
		page = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("start") && page == 0) {
			print ("one");
			animator.SetInteger ("page", 1);
			page = 1;
		}
		if (Input.GetButtonDown("Jump_1") && page == 1) {
			animator.SetInteger ("page", 2);
			page = 2;
		} 
		else if (Input.GetButtonDown("Jump_1") && page == 2) {
			Application.LoadLevel("backgroundtest");
		}
	}
}
