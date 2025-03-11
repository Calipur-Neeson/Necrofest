using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    [Header("Player Property")]
    public GameObject player;
    public GameObject weapon;
    [Range(1f, 1.2f)]
    public float jumpHeight;
    public float moveSpeed;
    
    [Header("Attack Property")]
    public float hitDamage;
    public float hitSpeed;

    [Range(0f, 100f)] 
    public float hitCriticalChance;
    public float hitDamageIncreaseRate;
    public float hitCriticalDamageIncresseRate;

    [Header("Range Attack Property")]
    public float rangeDamage;
    private float tempRangeDamage;
    public float moveSpeedMultiplier { get; set; } = 1f;
    public float jumpMultiplier { get; set; } = 1f;
    public float attackDistanceMultiplier { get; set; } = 1f;
    public float attackDamageMultiplier { get; set; } = 1f;
    public float rangeDamageMultiplier { get; set; } = 1f;
    public float eagleMultiplier { get; set; } = 0f;
    public float speedDaemonMultiplier { get; set; } = 0f;
    
    private float hitNormalDamage;
    private float hitCriticalDamage;
    private SwitchWeapon switchWeapon;
    private PlayerController playerControl;

    public string weaponName;
    public float damage;
    public float speed;
    public float distance;
    public float delay;
    public float animatorSpeed;
    private void Start()
    {
        tempRangeDamage = rangeDamage;
        playerControl = player.GetComponent<PlayerController>();
        switchWeapon = weapon.GetComponent<SwitchWeapon>();
        ResetPlayerAttackAnimation();
        //ResetPlayerProperty();
    }
 
    public void ResetPlayerAttackAnimation()
    {
        playerControl = player.GetComponent<PlayerController>();
        playerControl.attackDistance = switchWeapon.weaponDistance * attackDistanceMultiplier;
        playerControl.attackDelay = switchWeapon.weaponDelay;
        playerControl.attackSpeed = switchWeapon.weaponSpeed;
        playerControl.attackDamage = switchWeapon.weaponDamage * (attackDamageMultiplier + eagleMultiplier + speedDaemonMultiplier);
        playerControl.animator.speed = switchWeapon.attackAnimationSpeed;
        rangeDamage = tempRangeDamage * (rangeDamageMultiplier + eagleMultiplier + speedDaemonMultiplier);
    }
    public void ResetPlayerProperty()
    {
        playerControl = player.GetComponent<PlayerController>();
        playerControl.jumpHeight = jumpHeight * jumpMultiplier;
        playerControl.moveSpeed = moveSpeed * moveSpeedMultiplier;
        playerControl.moveSpeed_temp = moveSpeed * moveSpeedMultiplier;

    }
    public void CalculateHitDamage()
    {
        hitNormalDamage = playerControl.attackDamage * (1 + hitDamageIncreaseRate / 100);
        hitCriticalDamage = hitNormalDamage * 2 * (1 + hitCriticalDamageIncresseRate / 100);
        int i = Random.Range(0, 100);
        if (i < 0 + hitCriticalChance)
        {
            hitDamage = hitCriticalDamage;
        }
        else { hitDamage = hitNormalDamage; }
    }
}
