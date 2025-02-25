using System.Collections;
using UnityEngine;

public class EnemyKillTracker : MonoBehaviour
{
    public bool isKilled = false;  
    private Coroutine resetCoroutine; 
    private float resetTime = 5f; 

    public void OnEnemyKilled()
    {
        isKilled = true;
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
    }
}
