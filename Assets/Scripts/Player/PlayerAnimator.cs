using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator = null;
    private PlayerController player = null;

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", player.currentMovement.x);
        animator.SetFloat("Vertical", player.currentMovement.y);
        animator.SetFloat("Magnitude", player.currentMovement.magnitude);
    }
}
