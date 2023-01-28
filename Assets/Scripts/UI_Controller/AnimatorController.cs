using UnityEngine;

public class AnimatorController : MonoBehaviour {
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
