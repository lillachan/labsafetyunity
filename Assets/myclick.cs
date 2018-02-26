using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myclick : MonoBehaviour {

	public GameObject UI;
	bool x = false;
	public Text text;

	// Use this for initialization
	void Start () {
		UI = GameObject.FindWithTag ("Menu");
		UI.SetActive (x);
		if (UI != null) {
			text = UI.GetComponent<Text> ();
			Debug.Log (text);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		transform.localScale += new Vector3(0.1F, 0, 0);
		UI.SetActive(!x);
		x = !x;
	}
}
