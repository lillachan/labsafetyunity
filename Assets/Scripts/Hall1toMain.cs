using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Hall1toMain : MonoBehaviour {

    void onMouseUp()
    {
        SceneManager.LoadScene("Mainhall_2");
    }
}
