using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public SceneFader fader;

    public Button[] levelButtons;

    public int levelReached = 1;

    public playerMove player;

    void Start()
    {
        levelReached = player.levelreached;

        for (int i = 0; i < levelButtons.Length; i++) {
            if (i + 1 > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }
    public void Select(string levelName)
    {
        fader.FadeTo(levelName);
    }
}
