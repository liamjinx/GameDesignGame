using UnityEngine;

public class PetrifyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void playPetrifyAnimation()
    {
        if (!animator)
        {
            animator = GetComponent<Animator>();
        }

        ///if (gameObject.tag == "Ghost")
        //{
            //animator.SetTrigger("PetrifyGhost");
            if (gameObject.layer == LayerMask.NameToLayer("Phantom"))
            {
                animator.SetTrigger("PetrifyPhantom");
            } else if (gameObject.layer == LayerMask.NameToLayer("Wraith"))
            {
                animator.SetTrigger("PetrifyWraith");
            } else if (gameObject.layer == LayerMask.NameToLayer("Nuckelavee"))
            {
                animator.SetTrigger("PetrifyNuckelavee");
            } else if (gameObject.tag == "Ghost")
            {
                animator.SetTrigger("PetrifyGhost");
            }
            
        //}
        
        else
        {
            animator.SetTrigger("PetrifySubject");
        }
    }
}