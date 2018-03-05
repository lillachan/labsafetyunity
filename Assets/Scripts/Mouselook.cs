using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour {
	//public float turnSpeed = 50f;

	public float speedH = 2.0f;
	public float speedV = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;
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
		//MouseAiming ();
		yaw += speedH * Input.GetAxis("Mouse X");
		pitch -= speedV * Input.GetAxis("Mouse Y");

		transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

	}
} 