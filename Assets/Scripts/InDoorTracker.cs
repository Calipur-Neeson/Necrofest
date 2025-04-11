using System.Collections;
using UnityEngine;

public class InDoorTracker : MonoBehaviour
{
    private AttackManager attackManager;

    private bool isInsideRoom;
    private Coroutine buffCoroutine;
    private void Start()
    {
        attackManager = FindFirstObjectByType<AttackManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isInsideRoom) 
        {
            if (buffCoroutine == null) 
            {
                isInsideRoom = true; 
                buffCoroutine = StartCoroutine(BoostAttack()); 
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInsideRoom) 
        {           
            if (buffCoroutine != null) 
            {
                StopCoroutine(buffCoroutine);
                attackManager.attackDamageMultiplier -= 1.0f;
                attackManager.rangeDamageMultiplier -= 1.0f;
                attackManager.ResetPlayerAttackAnimation();
                buffCoroutine = null; 
                isInsideRoom = false; 
            }
        }
    }

    private IEnumerator BoostAttack()
    {
        attackManager.attackDamageMultiplier += 1.0f;
        attackManager.rangeDamageMultiplier += 1.0f;
        attackManager.ResetPlayerAttackAnimation();
        yield return new WaitForSeconds(10f);
        attackManager.attackDamageMultiplier -= 1.0f;
        attackManager.rangeDamageMultiplier -= 1.0f;
        attackManager.ResetPlayerAttackAnimation();
        buffCoroutine = null; 
        isInsideRoom = false; 
    }
}
