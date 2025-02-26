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
    public void OnEnemyKilled()
    {
        isKilled = true;
        if (!isIncreased)
        {
            attackManager.attackDistanceMultiplier *= 1.2f;
            attackManager.ResetPlayerAttackAnimation();
            isIncreased = true;
        }
        if (resetCoroutine != null)
        {
            StopCoroutine(resetCoroutine);
        }
        resetCoroutine = StartCoroutine(ResetKillStatus());
    }

    private IEnumerator ResetKillStatus()
    {
        yield return new WaitForSeconds(resetTime);
        isKilled = false;
        attackManager.attackDistanceMultiplier /= 1.2f;
        attackManager.ResetPlayerAttackAnimation();
        isIncreased = false;
    }
}
