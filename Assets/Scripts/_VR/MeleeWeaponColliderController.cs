using UnityEngine;

public class MeleeWeaponColliderController : MonoBehaviour
{
    private CapsuleCollider attackCollider;
    private Rigidbody rb;
    public float linearSpeedLimit;
    public float angularSpeedLimit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        attackCollider = GetComponent<CapsuleCollider>();
        attackCollider.isTrigger = false;
    }
    private void Update()
    {
        float linearSpeed = rb.linearVelocity.magnitude;
        float angularSpeed = rb.angularVelocity.magnitude;
        if (linearSpeed > linearSpeedLimit || angularSpeed > angularSpeedLimit) 
        {
            attackCollider.isTrigger = true;
        }
        else { attackCollider.isTrigger = false; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") )
        {
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(200, "Melee");
            }
        }
    }
}
