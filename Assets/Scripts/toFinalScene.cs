using UnityEngine;

public class toFinalScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseUpAsButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("FinalScene");
    }
}
