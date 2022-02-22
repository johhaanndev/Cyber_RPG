using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterAttack : MonoBehaviour
{
    private bool isAttacking;
    private bool isDashing;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();

        isAttacking = false;
        isDashing = false;
    }

    private void Update()
    {
        anim.SetBool("isDashing", isDashing);
    }

    public void BasicAttack()
    {
        isAttacking = true;
        anim.SetTrigger("isAttacking");
    }

    public void Dash()
    {
        isDashing = true;
    }

    // temporary method
    private void DisableAttack()
    {
        isAttacking = false;
    } 
    private void DisableDash() => isDashing = false;

    public bool GetIsAttacking() => isAttacking;

    public bool GetIsDashing() => isDashing;
}
