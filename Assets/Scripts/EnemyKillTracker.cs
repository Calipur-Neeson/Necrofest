using System.Collections;
using UnityEngine;

public class EnemyKillTracker : MonoBehaviour
{
    public bool isKilled = false;  
    private bool isIncreased = false;
    private Coroutine resetCoroutine; 
    private float resetTime = 5f;

    private GameObject player;
    private AttackManager attackManager;

    private void Start()
    {
        player = FindFirstObjectByType<PlayerController>().gameObject;

        attackManager = player.GetComponent<AttackManager>();
    }
    public void OnEnemyKilled(string weaponType)
    {
        if (weaponType == "Melee")
        {
            isKilled = true;
            if (!isIncreased)
            {
                attackManager.rangeDamageMultiplier += 0.2f;
                attackManager.ResetPlayerAttackAnimation();
                isIncreased = true;
            }
            if (resetCoroutine != null)
            {
                StopCoroutine(resetCoroutine);
            }
            resetCoroutine = StartCoroutine(ResetKillStatus());
        }
    }

    private IEnumerator ResetKillStatus()
    {
        yield return new WaitForSeconds(resetTime);
        isKilled = false;
        attackManager.rangeDamageMultiplier -= 0.2f;
        attackManager.ResetPlayerAttackAnimation();
        isIncreased = false;
    }
}
