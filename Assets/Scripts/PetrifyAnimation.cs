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

        if (gameObject.tag == "Ghost")
        {
            //animator.SetTrigger("PetrifyGhost");
        }
        
        else
        {
            //animator.SetTrigger("PetrifySubject");
        }
    }
}