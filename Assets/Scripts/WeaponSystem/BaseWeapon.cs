using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    [SerializeField] private WeaponData weaponData;
    public abstract void DealDamage();
    public abstract void UnEquip();
    public abstract void Equip();
    public abstract void Switch();
    public virtual void PickUpWeapon()
    {
        GameObject camera = GameObject.FindWithTag("MainCamera");
        transform.SetParent(camera.transform); 
        transform.localPosition = new Vector3(0.3f,0,0);
        transform.localRotation = Quaternion.identity;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            Destroy(rb);
        }
    }
}
