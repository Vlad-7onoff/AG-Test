using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelLoader : MonoBehaviour
{
    [SerializeField] private string _nextLevel;

    public void OnNextButtonClicked() {
        Scene loadedScene = SceneManager.GetSceneByName(_nextLevel);

        if (loadedScene.buildIndex != -1)
            SceneManager.LoadScene(loadedScene.buildIndex);
        else
            throw new System.Exception("Scene name incorrect");
    }
}
