using UnityEngine;

public class AnimatorBehaviour : MonoBehaviour {
    public Animator animator;

    public void ShowPanel() {
        animator.SetBool("isShow", true);
    }

    public void ClosePanel() {
        animator.SetBool("isShow", false);
    }
}
