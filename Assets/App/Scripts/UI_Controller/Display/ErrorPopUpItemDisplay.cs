using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ErrorPopUpItemDisplay : MonoBehaviour {
    private Animator animator;
    public Text title;
    public Text description;

    void Awake() {
        animator = transform.Find("Layout").GetComponent<Animator>();
    }

    void Start() {
        StartCoroutine(SelfDestruct());
    }

    public void Display(ErrorModel errorModel) {
        if (title != null) {
            title.text = errorModel.message;
        }
        if (description != null) {
            description.text = errorModel.description;
        }
    }

    public void Callback(string? value) {
        if (string.IsNullOrEmpty(value)) {
            Destroy(gameObject);
        }
    }

    private IEnumerator SelfDestruct() {
        yield return new WaitForSeconds(5f);
        Hide();
    }

    private void Show() {
        animator.SetBool("isShow", true);
    }

    private void Hide() {
        animator.SetBool("isShow", false);
    }
}
