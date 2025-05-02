using System.Collections;
using UnityEngine;

namespace AG2187
{
    public class AddChainSwings : MonoBehaviour
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
            if (attackManager.isChainSwing)
            {
                if (other.CompareTag("Enemy"))
                {
                    isChainSwings = true;
                    if (!isIncreased)
                    {
                        attackManager.attackDamageMultiplier += attackManager.chainSwingsMultiplier;
                        attackManager.ResetPlayerAttackAnimation();
                        isIncreased = true;
                    }
                    if (resetCoroutine != null)
                    {
                        StopCoroutine(resetCoroutine);
                    }
                    resetCoroutine = StartCoroutine(IncreaseMeleeDamage());
                }
            }
        }

        private IEnumerator IncreaseMeleeDamage()
        {
            yield return new WaitForSeconds(3f);
            isChainSwings = false;
            isIncreased = false;
            attackManager.attackDamageMultiplier -= attackManager.chainSwingsMultiplier;
            attackManager.ResetPlayerAttackAnimation();
        }
    } 
}
