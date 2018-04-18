using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomClick : MonoBehaviour {
	public startScore startScore;

	void onMouseUp(){
		PlayerPrefs.SetInt ("Score", PlayerPrefs.GetInt ("Score") - 1);
		Debug.Log ("Score = " + PlayerPrefs.GetInt ("Score"));
	}
}
