using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelControlScript : MonoBehaviour {


    int sceneIndex, levelPassed;

	// Use this for initialization
	void Start () {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
	}

    public void youWin() {
        if (sceneIndex == 1)
        {
            SceneManager.LoadScene("LevelSelect");
            PlayerPrefs.SetInt("LevelPassed", sceneIndex);
        }
        
            }
        
	// Update is called once per frame
	void Update () {
		
	}
}
