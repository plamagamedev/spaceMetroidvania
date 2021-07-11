using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralEnemyAnimatorController : MonoBehaviour
{
    public Animator animator;

    public const string deathAnimation = "DEATH";
    public const string walking = "WALKING";

    void Start()
    {
        animator = GetComponent<Animator>();
        PlayAnimation(walking);
    }
    public void Die()
    {
        PlayAnimation(deathAnimation);
        StartCoroutine("Destroy");
    }
    private void PlayAnimation(string anim)
    {
        animator.Play(anim);
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(.1f);
        while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < .98f)
        {
            yield return null;
        }
        Destroy(this.gameObject);
        // TODO: Do something when animation did complete
    }
}
