using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour {
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void MoveScanARScene() {
        SceneManager.LoadScene("ScanArScene", LoadSceneMode.Single);
    }

    public void MoveMainScene() {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void Exit() {
        Application.Quit();
    }
}
