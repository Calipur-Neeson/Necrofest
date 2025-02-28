using System.Collections;
using UnityEngine;

public class ChainSwings : MonoBehaviour
{
    private GameObject player;
    private AttackManager attackManager;
    private bool isChainSwings = false;
    private bool isIncreased = false;
    private Coroutine resetCoroutine;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>().gameObject;
        attackManager = player.GetComponent<AttackManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            isChainSwings = true;
            if (!isIncreased)
            {
                attackManager.attackDamageMultiplier *= 1.1f;
                attackManager.ResetPlayerAttackAnimation();
                isIncreased = true;
            }
            if (resetCoroutine != null)
            {
                StopCoroutine(resetCoroutine);
            }
            resetCoroutine = StartCoroutine(IncreaseDamage());
        }
    }

    private IEnumerator IncreaseDamage()
    {
        yield return new WaitForSeconds(3f);
        isChainSwings = false;
        isIncreased = false;
        attackManager.attackDamageMultiplier /= 1.1f;
        attackManager.ResetPlayerAttackAnimation();
    }
}
