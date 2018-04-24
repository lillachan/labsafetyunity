using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScore : MonoBehaviour {
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Score", 0);
		Debug.Log ("Score = " + PlayerPrefs.GetInt ("Score"));
	}
}