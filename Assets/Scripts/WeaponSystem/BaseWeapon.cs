using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [HideInInspector] public WeaponData weaponData;
    private AttackManager attackManager;

    protected virtual void start()
    {
        attackManager = FindFirstObjectByType<AttackManager>();
    }
    public virtual void Drop()
    {
        transform.SetParent(null);
        gameObject.AddComponent<Rigidbody>();
        GetComponent<BoxCollider>().enabled = true;
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