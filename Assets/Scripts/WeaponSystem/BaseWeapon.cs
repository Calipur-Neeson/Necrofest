using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    public abstract void DealDamage();
    public virtual void Drop()
    {
        transform.SetParent(null);
        gameObject.AddComponent<Rigidbody>();
    }
    
}
