using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    public GameObject player;
    private PlayerController playerControl;

    public GameObject weapon;
    private SwitchWeapon switchWeapon;

    public float jumpHeight;
    public float moveSpeed;
    public float hitDamage;
    public float hitSpeed;
    public float hitCriticalChance;
    public float hitDamageIncreaseRate;
    public float hitCriticalDamageIncresseRate;
    
    private float hitNormalDamage;
    private float hitCriticalDamage;
    private void Start()
    {
        playerControl = player.GetComponent<PlayerController>();
        switchWeapon = weapon.GetComponent<SwitchWeapon>();

    }

    public void ResetPlayerAttackAnimation()
    {
        playerControl.attackDistance = switchWeapon.weaponDistance;
        playerControl.attackDelay = switchWeapon.weaponDelay;
        playerControl.attackSpeed = switchWeapon.weaponSpeed;
        playerControl.attackDamage = switchWeapon.weaponDamage;
        playerControl.animator.speed = switchWeapon.attackAnimationSpeed;
    }
    public void ResetPlayerProperty()
    {
        playerControl.jumpHeight = jumpHeight;
        playerControl.moveSpeed = moveSpeed;

    }
    public void CalculateHitDamage()
    {
        hitNormalDamage = switchWeapon.weaponDamage * (1 + hitDamageIncreaseRate / 100);
        hitCriticalDamage = hitNormalDamage * 2 * (1 + hitCriticalDamageIncresseRate / 100);
        int i = Random.Range(0, 100);
        if (i < 0 + hitCriticalChance)
        {
            hitDamage = hitCriticalDamage;
        }
        else { hitDamage = hitNormalDamage; }
    }
}
