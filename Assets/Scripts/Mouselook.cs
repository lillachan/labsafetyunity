using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour {
	//public float turnSpeed = 50f;

	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;
	bool zoomToggle = false;
	private float normalFOV;

	void start() {
		normalFOV = Camera.current.fieldOfView;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void EnableMouse() {
		Cursor.lockState = CursorLockMode.Locked;
	}
	/*void MouseAiming()
	{
		var rot = new Vector3(0f, 0f, 0f);
		// rotates Camera Left
		if (Input.GetAxis("Mouse X") < 0)
		{
			rot.x -= 1;
		}
		// rotates Camera Left
		if (Input.GetAxis("Mouse X") > 0)
		{
			rot.x += 1;
		}

		// rotates Camera Up
		if (Input.GetAxis("Mouse Y") < 0)
		{
			rot.z -= 1;
		}
		// rotates Camera Down
		if (Input.GetAxis("Mouse Y") > 0)
		{
			rot.z += 1;
		}

		transform.Rotate(rot, turnSpeed * Time.deltaTime);
	}
*/
/*	void KeyboardMovement()
	{
		var sensitivity = 0.01f;
		var movementAmount = 0.5f;
		var movementVector = new Vector3(0f, 0f, 0f);
		var hMove = Input.GetAxis("Horizontal");
		var vMove = Input.GetAxis("Vertical");
		// left arrow
		if (hMove < -sensitivity) movementVector.x = -movementAmount;
		// right arrow
		if (hMove > sensitivity) movementVector.x = movementAmount;
		// up arrow
		if (vMove < -sensitivity) movementVector.y = -movementAmount;
		// down arrow
		if (vMove > sensitivity) movementVector.y = movementAmount;
		// Using Translate allows you to move while taking the current rotation into consideration
		transform.Translate(movementVector);
	} 
	// Use this for initialization
	//void Start () {
	//	
	//} */
	
	// Update is called once per frame
	void Update () {
		// Right-click zoom
		if (Input.GetMouseButton(1))
			//if (zoomToggle == false) {
			//	zoomToggle = true;
			Camera.current.fieldOfView = 20;
		//}
		else
		{
			//	zoomToggle = true;
			Camera.current.fieldOfView = 60;
		}
		//MouseAiming ();
		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

		// Lock mouse in center. Hold ESC to release.
		if (Input.GetKey (KeyCode.Escape))
			//Screen.lockCursor = false;
			Cursor.lockState = CursorLockMode.None;
		else
			Cursor.lockState = CursorLockMode.Locked;


	}
} 