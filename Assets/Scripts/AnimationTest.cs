using System.Collections;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    [SerializeField] Animator flyingEnemy;

    IEnumerator Animations()
    {
        flyingEnemy.SetBool("isAttacking", true);
        flyingEnemy.SetFloat("Attack", 1);
        yield return new WaitForSeconds(2);
    }
}
