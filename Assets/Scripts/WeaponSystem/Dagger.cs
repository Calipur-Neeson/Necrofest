using Unity.VisualScripting;
using UnityEngine;

public class Dagger : IMeleeWeapon
{
    private AttackManager attackManager;
    [SerializeField] private WeaponData weaponData;
    private void Start()
    {
        //weaponName = "Dagger";
        //damage = 25f;
        //speed = 1.0f; //bigger, slower
        //distance = 1.0f;
        //delay = 0.4f;
        //animatorSpeed = 1.0f;

        //attackManager = FindFirstObjectByType<AttackManager>();
        Debug.Log(weaponData.damage);
    }
    private void OnEnable()
    {
        
    }

    public void SwitchWeapon()
    {
        throw new System.NotImplementedException();
    }
}
