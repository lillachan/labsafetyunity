using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myclick : MonoBehaviour {

	public GameObject UI;
	public Text text;
	public GameObject cam;
	public GameObject mouseLookToggle;

	//public GameObject locker = Cursor.lockState;

	// Use this for initialization
	void Start () {
		UI = GameObject.FindWithTag ("Menu");
		UI.SetActive (false);
		if (UI != null) {
			text = UI.GetComponent<Text> ();
			Debug.Log (text);
		}
		cam = GameObject.FindWithTag ("MainCamera");

		Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
		if (UI.activeSelf) {
			Cursor.lockState = CursorLockMode.None;
			cam.GetComponent<Mouselook> ().enabled = false;
		}
	}

	void OnMouseUp() {
		//transform.localScale += new Vector3(0.1F, 0, 0);
		//UI.SetActive(!UI.activeInHierarchy);
		UI.SetActive(true);

		//GameObject cam = Camera.main;
		//GameObject cam = Camera.current;
		//cam.GetComponent<Mouselook>().enabled = false;
		cam.GetComponent<Mouselook>().enabled = false;
		Cursor.lockState = CursorLockMode.None;
		UnityEngine.Cursor.visible = true;

	}

	//public void camEnable() {
	//	cam.GetComponent<Mouselook> ().enabled = true;
	//}

}

