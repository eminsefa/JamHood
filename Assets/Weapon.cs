using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    Animator animator;
    string animation;

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        animation = GetComponentInParent<Player>().anim;
    }
    public void PlayAnimation()
    {
        if (animation == null) { return; }
        animator.SetTrigger("Attacking");
        animator.Play(animation,0);
    }
}
