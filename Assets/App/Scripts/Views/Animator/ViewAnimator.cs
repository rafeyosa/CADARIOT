using UnityEngine;

public class ViewAnimator : MonoBehaviour {
    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void Show() {
        animator.SetBool("isShow", true);
    }

    public void Hide() {
        animator.SetBool("isShow", false);
    }
}
