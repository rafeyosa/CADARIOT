using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour {
    static List<string> sceneList = new List<string>() { Constants.mainScene };

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Back();
        }
    }

    public void Back() {
        if (sceneList.Count > 1) {
            SceneManager.LoadScene(sceneList[sceneList.Count - 2], LoadSceneMode.Single);
            sceneList.RemoveAt(sceneList.Count - 1);
        } else {
            Application.Quit();
        }
    }

    public void MoveMainScene() {
        sceneList.Add(Constants.mainScene);
        SceneManager.LoadScene(Constants.mainScene, LoadSceneMode.Single);
    }

    public void MoveScanARScene() {
        sceneList.Add(Constants.scanArScene);
        SceneManager.LoadScene(Constants.scanArScene, LoadSceneMode.Single);
    }

    public void MoveLogScene() {
        sceneList.Add(Constants.logScene);
        SceneManager.LoadScene(Constants.logScene, LoadSceneMode.Single);
    }

    public void Exit() {
        Application.Quit();
    }
}
