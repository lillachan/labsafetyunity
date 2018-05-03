using UnityEngine;

public class toFinalScene : MonoBehaviour {
    public GameObject UI;
	// Use this for initialization
	void Start () {
        if (UI == null)
        {
            UI = GameObject.FindWithTag("Menu");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseUpAsButton()
    {
        if (UI == null)
        {
            foreach (Canvas c in Resources.FindObjectsOfTypeAll<Canvas>())
            {
                if (c.name == "QCanvas")
                {
                    UI = c.gameObject;
                    break;
                }
            }
        }
        if (UI.activeSelf == false)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("FinalScene");
        }
    }
}
