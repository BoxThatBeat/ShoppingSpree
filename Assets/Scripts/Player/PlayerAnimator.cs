using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator = null;
    private PlayerController player = null;

    void Awake()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<PlayerController>();

        player.currentMovement.y = -0.01f; //used to set the default position of the idle anim
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.currentMovement.magnitude > 0.01)
        {
            if (!animator.GetBool("Started"))
                animator.SetBool("Started", true);

            animator.SetFloat("Horizontal", player.currentMovement.x);
            animator.SetFloat("Vertical", player.currentMovement.y);
            animator.SetFloat("Magnitude", player.currentMovement.magnitude);
        }
        else //only update the magnitude to come out of idle
        {
            animator.SetFloat("Magnitude", player.currentMovement.magnitude);
        } //the idle animations will have a set direction based on the axes set before going into this block of code
    }
}
