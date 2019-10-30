using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NVS_HangarManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("NVS_MainMenu");
    }
}
