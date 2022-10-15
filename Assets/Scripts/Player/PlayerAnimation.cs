using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public float Speed { set { animator.SetFloat("Speed", value); } private get { return animator.GetFloat("Speed"); } }

    public void Sit(){
        animator.SetBool("Sit", true);
    }
    public void Dive(){
        animator.SetBool("Dive", true);
    }
}
