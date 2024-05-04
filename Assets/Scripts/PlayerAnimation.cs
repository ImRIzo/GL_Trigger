using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    public void PlayRunAnimation()
    {
        animator.Play("Run");
    }
    public void PlayAnimation(string animationName)
    {
        animator.Play(animationName);
    }
    public void PlayAnimation(string animationName, float animationSpeed)
    {
        animator.speed = animationSpeed;
        PlayAnimation(animationName);
    }
}
