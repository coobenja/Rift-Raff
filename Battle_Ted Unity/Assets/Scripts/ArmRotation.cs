using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {
	

	float rotationY = 0f;
	Quaternion originalRotation;
	public string horizontalAim;
	public string verticalAim;

	public float projectileVelocity;

	public Rigidbody2D forceBallPrefab;
	public Rigidbody2D hammerPrefab;

	public string triggerIn;

	public Transform firePoint;
	//public Transform firePointHand;
	//public Transform firePointHammer;
	public bool hasHammer = false;
	public GameObject myHammer;

	void Awake () {
		//firePoint = transform.Find ("firePoint");

	}

	void Update () {

		if(Input.GetAxis(horizontalAim) != 0f  || Input.GetAxis(verticalAim) != 0f)
			rotationY = -90f + 180f/3.14f * Mathf.Atan2(Input.GetAxis(horizontalAim), Input.GetAxis (verticalAim));
		
		//rotationY = ClampAngle (rotationY, minimumY, maximumY);
		
		Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.back);
		
		transform.rotation = yQuaternion;


		if (hasHammer) 
		{
			//firePoint = firePointHammer;
			myHammer.SetActive(true);
		}
		else
		{
			//firePoint = firePointHand;
			myHammer.SetActive(false);
		}


		//Shooting mechanics
		if(Input.GetButtonDown(triggerIn) && !hasHammer)
		{
			Rigidbody2D forceBallInstance;
			forceBallInstance = Instantiate(forceBallPrefab, firePoint.position , yQuaternion) as Rigidbody2D;
			forceBallInstance.AddForce(firePoint.right * projectileVelocity, ForceMode2D.Impulse);
		}
		//Hammer Shot
		if(Input.GetButtonDown(triggerIn) && hasHammer)
		{
			Rigidbody2D hammerInstance;
			hammerInstance = Instantiate(hammerPrefab, firePoint.position , yQuaternion) as Rigidbody2D;
			hammerInstance.AddForce(firePoint.right * projectileVelocity, ForceMode2D.Impulse);
			hasHammer = false;
		}
	}
	
	void Start () { 
		if (rigidbody) rigidbody.freezeRotation = true; 
		originalRotation = transform.localRotation; 
	}
	
	public static float ClampAngle (float angle, float min, float max) { 
		if (angle < -360F) angle += 360F; if (angle > 360F) angle -= 360F; return Mathf.Clamp (angle, min, max); 
	}
	
} 

