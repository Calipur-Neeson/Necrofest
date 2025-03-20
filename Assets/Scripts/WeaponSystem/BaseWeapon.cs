using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    private AttackManager attackManager;

    protected virtual void start()
    {
        attackManager = FindFirstObjectByType<AttackManager>();
    }
    public abstract void DealDamage();
    public virtual void Drop()
    {
        transform.SetParent(null);
        gameObject.AddComponent<Rigidbody>();
    }

    public virtual void SendMeleeInfo()
    {
        attackManager = FindFirstObjectByType<AttackManager>();
        attackManager.weaponName = weaponData.weaponName;
        attackManager.damage = weaponData.damage;
        attackManager.speed = weaponData.speed;
        attackManager.distance = weaponData.distance;
        attackManager.delay = weaponData.delay;
        attackManager.animatorSpeed = weaponData.animatorSpeed;
        attackManager.ResetPlayerAttackAnimation();
    }
}