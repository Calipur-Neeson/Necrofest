using UnityEngine;
using UnityEngine.InputSystem;

public class AttackManager : MonoBehaviour
{
    public static AttackManager instance;
    [Header("Player Property")]
    public GameObject player;

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
    public float rangeDamage = 90.0f;
    [HideInInspector] public float tempRangeDamage = 90.0f;
    public float moveSpeedMultiplier { get; set; } = 1f;
    public float jumpMultiplier { get; set; } = 1f;
    public float attackDistanceMultiplier { get; set; } = 1f;
    public float attackDamageMultiplier { get; set; } = 1f;
    public float rangeDamageMultiplier { get; set; } = 1f;
    public float eagleMultiplier { get; set; } = 0f;
    public float speedDaemonMultiplier { get; set; } = 0f;
    public float chainSwingsMultiplier { get; set; } = 0f;
    public float attackSpeedMultiplier { get; set; } = 1f;
    [HideInInspector] public bool isChainSwing;

    private float hitNormalDamage;
    private float hitCriticalDamage;
    private PlayerController playerControl;


    public string weaponName;
    public float damage;
    public float speed;
    public float distance;
    public float delay;
    public float animatorSpeed;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    [HideInInspector] public bool isCriticalChain;
    private bool isLastAttackCritical;
    private float temp_CriticalChance;

    private void Start()
    {
        tempRangeDamage = rangeDamage;
        playerControl = player.GetComponent<PlayerController>();
        ResetPlayerAttackAnimation();
        //ResetPlayerProperty();
    }
 
    public void ResetPlayerAttackAnimation()
    {
        playerControl = player.GetComponent<PlayerController>();
        playerControl.attackDistance = distance * attackDistanceMultiplier;
        playerControl.attackDelay = delay;
        playerControl.attackSpeed = speed * attackSpeedMultiplier;
        playerControl.attackDamage = damage * (attackDamageMultiplier + eagleMultiplier + speedDaemonMultiplier);
        playerControl.animator.speed = animatorSpeed * attackSpeedMultiplier;
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

        hitDamage = (i < hitCriticalChance) ? hitCriticalChance : hitNormalDamage;
        //if (i < hitCriticalChance)
        //{
        //    hitDamage = hitCriticalDamage;
        //}
        //else { hitDamage = hitNormalDamage; }

        if (i < hitCriticalChance)
        {
            hitDamage = hitCriticalDamage;
            if (isCriticalChain)
            {
                if(!isLastAttackCritical)
                {
                    hitCriticalChance *= 2;
                    isLastAttackCritical = true;
                }
                else
                {
                    hitCriticalChance /= 2; 
                    isLastAttackCritical = false;
                }
            }
        }
        else { hitDamage = hitNormalDamage; }

    }

}
