using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalMenu : MonoBehaviour {

	public void PlayGame ()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame ()
    {
        Application.Quit();
    }
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

}
