using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startScore : MonoBehaviour {
	// Use this for initialization
	void Start () {
		PlayerPrefs.SetInt ("Score", 0);
	}
}