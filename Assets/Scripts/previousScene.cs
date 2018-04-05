using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class previousScene : MonoBehaviour {

	void onMouseUp(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
	}
}
