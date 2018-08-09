using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static LevelManager instance = null;

    int levelPassed, sceneIndex;

	// Use this for initialization
	void Start () {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
		
	}
    public void EndStage() {
        Invoke("loadstageselect", 1f);
    }
    void loadstageselect() {
        SceneManager.LoadScene("Stage select");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
