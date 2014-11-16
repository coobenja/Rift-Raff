using UnityEngine;
using System.Collections;

public class ArmRotation : MonoBehaviour {
	
	public float minimumY = -90F; 
	public float maximumY = 90F;
	float rotationY = 0f;
	Quaternion originalRotation;
	public string horizontalAim;
	public string verticalAim;

	public float projectileVelocity;

	public Rigidbody2D forceBallPrefab;

	public string triggerIn;

	private Transform firePoint;
	public Transform firePointHand;
	public Transform firePointHammer;
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
			firePoint = firePointHammer;
			myHammer.SetActive(true);
		}
		else
		{
			firePoint = firePointHand;
			myHammer.SetActive(false);
		}


		//Shooting mechanics
		if(Input.GetButtonDown(triggerIn))
		{
			Rigidbody2D forceBallInstance;
			forceBallInstance = Instantiate(forceBallPrefab, firePoint.position , yQuaternion) as Rigidbody2D;
			forceBallInstance.AddForce(firePoint.right * projectileVelocity, ForceMode2D.Impulse);
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

