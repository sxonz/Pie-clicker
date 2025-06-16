using UnityEngine;

public class AnimationSync : MonoBehaviour
{
    public Animator animator;
    private float animationLength = 1f;
    private float startTime;
    bool flag;

    void Start()
    {
        startTime = Time.time;
    }

    public void Sync()
    {
        if (flag)
        {
            flag = false;
            float elapsed = (Time.time - startTime) % animationLength;
            float normalizedTime = elapsed / animationLength;
            animator.Play("Normal", 0, normalizedTime);
            animator.Update(0f);
        }

    }

    public void Re()
    {
        flag = true;
    }
}
