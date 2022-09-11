using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneForDeviceSaveState : MonoBehaviour {
    [SerializeField]
    private DeviceSaveManager _deviceSaveManager;
    [SerializeField]
    private string _sceneForSaveExist;
    [SerializeField]
    private string _sceneForNoSave;

    private Coroutine _coroutine;

    public void Trigger() {
        if(_coroutine == null) {
            _coroutine = StartCoroutine(LoadSceneCoroutine());
        }
    }

    private IEnumerator LoadSceneCoroutine() {
        var saveExistTask = _deviceSaveManager.SaveExist();
        yield return new WaitUntil(() => saveExistTask.IsCompleted);
        if(saveExistTask.Result) {
            SceneManager.LoadScene(_sceneForSaveExist);
        } else {
            SceneManager.LoadScene(_sceneForNoSave);
        }
        _coroutine = null;
    }
}
