using UnityEngine;

public class WeaponTrigger : MonoBehaviour
{
    
    public GameObject player;
    private AttackManager attackManager;

    private void Start()
    {
        attackManager = player.GetComponent<AttackManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //int layer = other.gameObject.layer;
        if (other.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                attackManager.CalculateHitDamage();
                float damage = attackManager.hitDamage;
                enemyHealth.TakeDamage(damage);
            }
        }
    }
}
