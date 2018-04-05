/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myclick_back : MonoBehaviour {

	public GameObject UI;
	public Text text;



	// Use this for initialization
	void Start () {
		UI = GameObject.FindWithTag ("Menu");
		//UI.SetActive (false);
		//if (UI != null) {
		//	text = UI.GetComponent<Text> ();
		//	Debug.Log (text);
		}

	}

	// Update is called once per frame
	//void Update () {

	//}

	void OnMouseUp() {
		//transform.localScale += new Vector3(0.1F, 0, 0);
		//UI.SetActive(!UI.activeInHierarchy);
		UI.SetActive(false);
		Cursor.lockState = CursorLockMode.None;

		GameObject cam = GameObject.FindWithTag ("MainCamera");
		cam.GetComponent<Mouselook>().enabled = false;
	}
}
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class myclick_back : MonoBehaviour
{
	public Button btn;

	void Start()
	{
		Button backButton = btn.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	void TaskOnClick()
	{
		Debug.Log("You have clicked the button!");
	}
}