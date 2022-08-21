using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    public void MoveScanARScene()
    {
        SceneManager.LoadScene("StartScanScene", LoadSceneMode.Single);
    }

    public void MoveLibraryScene()
    {
        SceneManager.LoadScene("SinopsisScene", LoadSceneMode.Single);
    }

    public void MoveHelpScene()
    {
        SceneManager.LoadScene("HelpScene", LoadSceneMode.Single);
    }

    public void MoveInfoScene()
    {
        SceneManager.LoadScene("AboutScene", LoadSceneMode.Single);
    }

    public void BackMainScene()
    {
        SceneManager.LoadScene("MainMenuScene", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
