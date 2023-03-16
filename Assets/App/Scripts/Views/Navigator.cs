using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigator : MonoBehaviour {
    public void MoveMainScene() {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }

    public void MoveScanARScene() {
        SceneManager.LoadScene("ScanArScene", LoadSceneMode.Single);
    }

    public void MoveLogScene() {
        SceneManager.LoadScene("LogScene", LoadSceneMode.Single);
    }

    public void Exit() {
        Application.Quit();
    }
}
