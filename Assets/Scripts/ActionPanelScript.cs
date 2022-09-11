using UnityEngine;

public class ActionPanelScript : MonoBehaviour {
    public Animator animator;

    public void ShowPanel() {
        animator.SetBool("isShow", true);
    }

    public void ClosePanel() {
        animator.SetBool("isShow", false);
    }
}
