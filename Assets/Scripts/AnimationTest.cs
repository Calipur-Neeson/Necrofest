using System.Collections;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    [SerializeField] Animator flyingEnemy;
    [SerializeField] Animator cardNPC;
    [SerializeField] Animator hayguy;
    [SerializeField] Animator coffinguy;
    [SerializeField] Animator boss;

    public void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            flyingEnemy.SetBool("isAttacking", true);
            cardNPC.SetBool("isVisible", false);
            hayguy.SetBool("isAttacking", true);
            coffinguy.SetBool("isAttacking", true);
            boss.SetBool("isFastAttacking", true);
        }

        if (Input.GetKeyDown("v"))
        {
            boss.SetBool("isSlowAttacking", true);
        }

        if (Input.GetKeyDown("b"))
        {
            coffinguy.SetBool("isWalking", true);
            boss.SetBool("isWalking", true);
        }

        if (Input.GetKeyDown("n"))
        {
            flyingEnemy.SetBool("isDead", true);
            hayguy.SetBool("isDead", true);
            coffinguy.SetBool("isDead", true);
            boss.SetBool("isDead", true);
        }
    }
}
