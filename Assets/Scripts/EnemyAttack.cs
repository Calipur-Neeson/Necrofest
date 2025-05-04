using UnityEngine;
using AG2187;
public class EnemyAttack : MonoBehaviour
{
    private BoxCollider attackCollider;

    private void Start()
    {
        attackCollider = GetComponentInChildren<BoxCollider>();
        if (attackCollider != null)
            attackCollider.enabled = false;
    }

    public void EnableAttack()
    {
        attackCollider.enabled = true;
    }

    public void DisableAttack()
    {
        attackCollider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("hit");
            VRPlayerHealth playerHealth = other.GetComponent<VRPlayerHealth>();
            playerHealth.PlayerGetHurt();
        }
    }
}
