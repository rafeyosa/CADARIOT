using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogController : MonoBehaviour {
    private Transform container;
    private DataService dataService;
    public LogItemDisplay logItemDisplayPrefab;

    void Awake() {
        container = transform.Find("Container");
    }

    void Start() {
        dataService = new DataService(Constants.localDatabase);
        GetLog();
    }

    private void GetLog() {
        IEnumerable<ErrorModel> logList = GetAllErrorList();
        foreach (var log in logList) {
            DisplayLog(log);
        }
    }

    private IEnumerable<ErrorModel> GetAllErrorList() {
		var errors = dataService.GetAllErrorList();
        return errors;
	}

    public void DisplayLog(ErrorModel item) {
        LogItemDisplay display = (LogItemDisplay)Instantiate(logItemDisplayPrefab);
        display.transform.SetParent(container, false);
        display.Display(item);
    }
}
