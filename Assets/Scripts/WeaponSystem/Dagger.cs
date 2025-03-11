using Unity.VisualScripting;
using UnityEngine;

public class Dagger : Weapon, IMeleeWeapon
{
    private AttackManager attackManager;
    private void Start()
    {
        weaponName = "Dagger";
        damage = 25f;
        speed = 1.0f; //bigger, slower
        distance = 1.0f;
        delay = 0.4f;
        animatorSpeed = 1.0f;

        attackManager = FindFirstObjectByType<AttackManager>();
    }
    private void OnEnable()
    {
        
    }

    public void SwitchWeapon()
    {
        throw new System.NotImplementedException();
    }
}
