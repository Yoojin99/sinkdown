using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectMenuControlScript : MonoBehaviour {

    public Button level02Button, resetbutton;
    int levelPassed;

	// Use this for initialization
	void Start () {
        levelPassed = PlayerPrefs.GetInt("LevelPassed");
        level02Button.interactable = false;

        switch (levelPassed) {
            case 1:
                level02Button.interactable = true;
                break;
        }
	}

    public void levelToLoad(string level) {
        SceneManager.LoadScene(level);

    }

    public void resetPlayerPrefs() {
        level02Button.interactable = false;
        PlayerPrefs.DeleteAll();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
